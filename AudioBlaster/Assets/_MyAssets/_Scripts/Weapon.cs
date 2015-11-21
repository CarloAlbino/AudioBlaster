using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    /// <summary>
    /// Weapon name.
    /// </summary>
    public string weaponName;

    /// <summary>
    /// Speed of the projectile.
    /// </summary>
    [SerializeField]
    protected float speed = 1.0f;

    /// <summary>
    /// Stores the current velocity of the projectile.
    /// </summary>
    protected Vector3 velocity;

    /// <summary>
    /// Time to reach target.
    /// </summary>
    [SerializeField]
    protected float timeToTarget = 1.0f;

    /// <summary>
    /// Damage done by the weapon.
    /// </summary>
    [SerializeField]
    protected float damage;

    /// <summary>
    /// Time before self-destruct.
    /// </summary>
    [SerializeField]
    protected float selfDestructTime = 10.0f;

    /// <summary>
    /// Reference to the player.
    /// </summary>
    protected Player _player;

    /// <summary>
    /// Reference to the target.
    /// </summary>
    protected Vector3 target;

    /// <summary>
    /// Level of the upgrade.
    /// </summary>
    public int upgradeLevel;

    /// <summary>
    /// Highest upgrade level.
    /// </summary>
    private int maxUpgradeLevel = 2;

    /// <summary>
    /// Upgrade points need to upgrade to the next level. Index 0 = points to go from level 1 to 2. Index 1 = points to go from index 2 to 3.
    /// </summary>
    [SerializeField]
    protected int[] upgradePointsNeeded = new int[2];

    /// <summary>
    /// Holds sprite for projectile at each upgrade level.
    /// </summary>
    [SerializeField]
    protected Sprite[] projectile;

    /// <summary>
    /// Cooldown for if the projectile can be fired.
    /// </summary>
    [SerializeField]
    protected float coolDown;

    /// <summary>
    /// Setup to do when weapon is spawned. To be called in Start.
    /// </summary>
    protected void OnStart()
    {
        _player = FindObjectOfType<Player>();
        NewTarget(_player.GetMouseClickPosition());
        damage = 10;
        upgradeLevel = 0;
    }

    /// <summary>
    /// Setup to do when weapon is spawned. To be called in Start, option to destroy projectile.
    /// </summary>
    /// <param name="destroyTime">Time to projectile destruction</param>
    protected void OnStart(float destroyTime)
    {
        _player = FindObjectOfType<Player>();
        NewTarget(_player.GetMouseClickPosition());
        DestroyCount(destroyTime);
        damage = 10;
        upgradeLevel = 0;
    }

    protected void UpdateMousePositionTarget()
    {
        NewTarget(_player.GetMouseClickPosition());
    }

    /// <summary>
    /// Set a new target for the weapon.
    /// </summary>
    /// <param name="t">Vector3, the position of the new target.</param>
    public void NewTarget(Vector3 t)
    {
        target = t;
    }

    /// <summary>
    /// Go towards the target. To be called in Update.
    /// </summary>
    protected void SeekTarget()
    {
        float moveSpeed = speed * Time.deltaTime;
        this.transform.position = Vector3.MoveTowards(transform.position, target * 10, moveSpeed);
    }

    /// <summary>
    /// Creates a sine wave pattern for the prjectile.
    /// </summary>
    /// <param name="frequency">Frequency of the sine wave.</param>
    /// <param name="magnitude">Magnitude of the sine wave.</param>
    protected void ZigZag(float frequency, float magnitude)
    {
        Vector3 temp = transform.position;
        transform.position = temp + new Vector3(transform.localPosition.x, transform.localPosition.y, 0) * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    bool flip = false;
    /// <summary>
    /// Expand and contract the projectile.
    /// </summary>
    /// <param name="maxSize">Maximum size of the projectile.</param>
    /// <param name="minSize">Minimum size of the projectile.</param>
    /// <param name="expandRate">Rate at which the projectile will expand.</param>
    protected void Expand(float maxSize,float minSize, float expandRate)
    {
        Vector3 temp = transform.localScale;
        
        if (!flip)
        {
            if (temp.x < maxSize)
            {
                temp *= expandRate;
                transform.localScale += temp;
            }
            else
            {
                flip = true;
            }
        }
        else
        {
            if (temp.x > minSize)
            {
                temp *= expandRate;
                transform.localScale += temp;
            }
            else
            {
                flip = false;
            }
        }
    }

    /// <summary>
    /// Get the projectile's velocity.
    /// </summary>
    private void GetVelocity()
    {
        velocity = target - transform.position;
    }

    /// <summary>
    /// Move Projectile towards target.
    /// </summary>
    protected void MoveToTarget()
    { 
        GetVelocity();
        velocity /= timeToTarget;
        if (velocity.magnitude > speed)
        {
            velocity.Normalize();
            velocity *= speed;
        }
        this.transform.Translate(velocity /* speed*/ * Time.deltaTime);
    }

    /// <summary>
    /// Moves the projectile forward.
    /// </summary>
    protected void MoveForward()
    {
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Rotates the projectile towards mouse potition.
    /// </summary>
    protected void RotateTowardsTarget(GameObject self)
    {
        GetVelocity();
        velocity.Normalize();
       // Vector3 newDir = Vector3.RotateTowards(self.transform.up, velocity, 1, 0f);
        //float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        self.transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
    }

    /// <summary>
    /// Destroy the object after a certain amount of time.
    /// </summary>
    /// <param name="seconds">Time until destruction.</param>
    protected void DestroyCount(float seconds)
    {
        selfDestructTime = seconds;
        StartCoroutine(DestroyCount());
    }

    /// <summary>
    /// Delay before destroying the object.
    /// </summary>
    /// <returns>Yield</returns>
    private IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(selfDestructTime);
        DestroyProjectile();
    }

    /// <summary>
    /// Destroys the object.
    /// </summary>
    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// Upgrade weapon level to level passed in.
    /// </summary>
    /// <param name="level">The new level. 0, 1, or 2.</param>
    public void UpgradeWeapon(int level)
    {
        upgradeLevel = level;
        if (upgradeLevel > maxUpgradeLevel)
        {
            upgradeLevel = maxUpgradeLevel;
        }
        if (upgradeLevel < 0)
        {
            upgradeLevel = 0;
        }
    }

    /// <summary>
    /// Damage done by the projectile.
    /// </summary>
    /// <returns>The damage.</returns>
    public float GetDamage()
    {
        return damage;
    }

    public int GetPointsNeeded()
    {
        if(upgradeLevel < 2)
            return upgradePointsNeeded[upgradeLevel];
        else
            return -1; // In controller if < 0 then you can no longer upgrade.
    }

    /// <summary>
    /// Get the cooldown time for the projectile.
    /// </summary>
    /// <returns>Cool down time(float).</returns>
    public float GetCooldownTime()
    {
        return coolDown;
    }

    /// <summary>
    /// For Debug
    /// </summary>
    /// <returns></returns>
    public Vector3 GetCurrentTarget()
    {
        return target;
    }
}
