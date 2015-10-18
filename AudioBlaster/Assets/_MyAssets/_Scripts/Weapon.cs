using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

    /// <summary>
    /// Speed of the projectile.
    /// </summary>
    [SerializeField]
    protected float speed = 1.0f;

    /// <summary>
    /// Damage done by the weapon.
    /// </summary>
    [SerializeField]
    protected float damage = 10.0f;

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
    /// Setup to do when weapon is spawned. To be called in Start.
    /// </summary>
    protected void OnStart()
    {
        _player = FindObjectOfType<Player>();
        NewTarget(_player.GetMouseClickPosition());
        StartCoroutine(DestroyCount());
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
    /// Delay before destroying the object.
    /// </summary>
    /// <returns>Yield</returns>
    private IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(selftDestructTime);
        DestroyProjectile();
    }

    /// <summary>
    /// Returns the amount of damage done by the weapon.
    /// </summary>
    /// <returns>The damage.</returns>
    public float GetDamage()
    {
        return damage;
    }

    /// <summary>
    /// Destroys the object.
    /// </summary>
    public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
}
