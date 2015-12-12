using UnityEngine;
using System.Collections;

public class EnemyBossMinion : MonoBehaviour
{
    #region Weapon Variables
    [SerializeField]
    protected GameObject projectile;

    protected bool canFire = false;

    [SerializeField]
    protected int percentageOfFire = 35;
    #endregion Weapon Variables

    #region Movement Variables
    [SerializeField]
    protected float maxSpeed = 10.0f;

    [SerializeField]
    protected float timeToTarget = 0.5f;

    [SerializeField]
    protected float radiusOfTarget = 2.0f;

    protected Player playerObject;

    protected Vector3 _player;

    protected Vector3 velocity;
    #endregion Movement Variables

    #region Monobehaviour
    // Use this for initialization
    void Start()
    {
        playerObject = FindObjectOfType<Player>();
        StartCoroutine(RandomShooting());
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }
    #endregion Monobehaviour

    #region AI
    protected void GetPlayerPosition()    // Not effecient for this particular enemy, should be called every frame when the player is moving.
    {
        _player = playerObject.transform.position;
    }

    protected void GetVelocity()
    {
        GetPlayerPosition();
        velocity = _player - transform.position;
    }

    protected void MoveToTarget()
    {
        GetVelocity();
        if (velocity.magnitude < radiusOfTarget)
        {
            canFire = true;
        }
        else
        {
            velocity /= timeToTarget;

            if (velocity.magnitude > maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            this.transform.Translate(velocity * maxSpeed * Time.deltaTime);
        }

    }

    public void NewTarget(Vector3 t)
    {
        _player = t;
        //Debug.Log("target" + _player);
    }

    public void RotateTowardsPlayer()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, transform.position - _player);
    }
    #endregion AI

    #region Weapons
    protected void FireWeapon()
    {
        Instantiate(projectile, this.gameObject.transform.position, Quaternion.identity);
    }

    protected IEnumerator RandomShooting()
    {
        float randomTime = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(randomTime);
        if (canFire)
        {
            int n = Random.Range(0, 100);
            if (n < percentageOfFire)
                FireWeapon();
        }
        StartCoroutine(RandomShooting());
    }
    #endregion Weapons
    /*bool gotTarget = false;
    Vector3 target;
    public float maxSpeed;
    public float timeToTarget;

    void Start()
    {
        StartCoroutine(DestroySelf());
    }
	
	// Update is called once per frame
	void Update () {
        if (gotTarget)
            MoveToTarget();
	}

    public void SetTarget(Vector3 pos)
    {
        Debug.Log("Target Set");
        target = pos;
        gotTarget = true;
        Debug.Log(gotTarget);
    }

    void MoveToTarget()
    {
        Vector3 dir = target - transform.position;

        dir /= timeToTarget;

        if (dir.magnitude > maxSpeed)
        {
            dir.Normalize();
            dir *= maxSpeed;
        }
        this.transform.Translate(dir * maxSpeed * Time.deltaTime);
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }*/
}
