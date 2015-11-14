using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    #region Weapon Variables
    [SerializeField]
    private GameObject projectile;

    private bool canFire = false;
    #endregion Weapon Variables

    #region Movement Variables
    [SerializeField]
    private float maxSpeed = 10.0f;

    [SerializeField]
    private float timeToTarget = 0.5f;

    [SerializeField]
    private float radiusOfTarget = 2.0f;

    private Vector3 _player;

    private Vector3 velocity;
    #endregion Movement Variables

    #region Monobehaviour
    // Use this for initialization
	void Start () {
        GetPlayerPosition();
        StartCoroutine(RandomShooting());
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}
    #endregion Monobehaviour

    #region AI
    private void GetPlayerPosition()    // Not effecient for this particular enemy, should be called every frame when the player is moving.
    {
        _player = FindObjectOfType<Player>().transform.position;
    }

    private void GetVelocity()
    {
        velocity = _player - transform.position;
    }

    private void MoveToTarget()
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
    #endregion AI

    #region Weapons
    private void FireWeapon()
    {
        Instantiate(projectile, this.gameObject.transform.position, Quaternion.identity);
    }

    private IEnumerator RandomShooting()
    {
        float randomTime = Random.Range(0.5f, 2.5f);
        yield return new WaitForSeconds(randomTime);
        if(canFire)
            FireWeapon();
        StartCoroutine(RandomShooting());
    }
    #endregion Weapons
}
