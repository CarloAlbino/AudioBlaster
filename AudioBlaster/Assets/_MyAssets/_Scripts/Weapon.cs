using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

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
    protected float damage { get; set; }

    /// <summary>
    /// Time before self-destruct.
    /// </summary>
    [SerializeField]
    protected float selftDestructTime = 10.0f;

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
    protected int upgradeLevel { get; set; }

    private int maxUpgradeLevel = 2;

    /// <summary>
    /// Setup to do when weapon is spawned. To be called in Start.
    /// </summary>
    protected void OnStart()
    {
        _player = FindObjectOfType<Player>();
        NewTarget(_player.GetMouseClickPosition());
        StartCoroutine(DestroyCount());
        damage = 10;
        upgradeLevel = 0;
    }

    /// <summary>
    /// Set a new target for the weapon.
    /// </summary>
    /// <param name="t">Vector3, the position of the new target.</param>
    protected void NewTarget(Vector3 t)
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
    /// Delay before destroying the object.
    /// </summary>
    /// <returns>Yield</returns>
    private IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(selftDestructTime);
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
    /// Upgrade weapon by one level.
    /// </summary>
    public void UpgradeWeapon()
    {
        if (upgradeLevel < maxUpgradeLevel)
        {
            upgradeLevel++;
        }
    }
}
