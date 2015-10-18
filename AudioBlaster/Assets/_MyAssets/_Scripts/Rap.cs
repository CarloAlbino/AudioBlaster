using UnityEngine;
using System.Collections;

public class Rap : Weapon {

    /// <summary>
    /// Max range to find another target.
    /// </summary>
    [SerializeField]
    private float range = 5.0f;

    /// <summary>
    /// Max time before the projectile will cease seeking additional targets.
    /// </summary>
    [SerializeField]
    private float timeToSeek = 3f;

    /// <summary>
    /// Total ammout of hits to destroy this weapon's projectile.
    /// </summary>
    [SerializeField]
    private int maxHits = 3;

    /// <summary>
    /// Current amount of hits.
    /// </summary>
    private int hitCount = 0;

    /// <summary>
    /// CAn the projectile seek the target.
    /// </summary>
    private bool canSeek = true;

    private Transform nextTarget = null;

	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (canSeek)
        {
            SeekTarget();
            if (nextTarget != null)
            {
                NewTarget(nextTarget.position);
            }
        }
        if (hitCount > maxHits)
            DestroyProjectile();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (canSeek)
        {
            if (hitCount <= maxHits)
            {
                if (other.CompareTag("Enemy"))
                {
                    StopCoroutine(SeekTime());
                    Invoke("FindNextTarget", 0.2f);
                    StartCoroutine(SeekTime());
                }
            }
        }
    }

    /// <summary>
    /// Counts the time the projectile is allowed to seek a new target.
    /// </summary>
    /// <returns>Yield</returns>
    private IEnumerator SeekTime()
    {
        yield return new WaitForSeconds(timeToSeek);
        canSeek = false;
        damage /= 2;
    }

    /// <summary>
    /// Finds a new enemy to target.
    /// </summary>
    private void FindNextTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        /*for (int i = 0; i < enemies.Length; i++)
        {
            Vector3 distance = enemies[i].transform.position - this.gameObject.transform.position;
            if (distance.magnitude < range)
            {
                NewTarget(enemies[i].transform.position);
                break;
            }
        }*/
        nextTarget = FindNearestTarget(enemies);
        hitCount++;
        speed *= 1.25f;
    }

    private Transform FindNearestTarget(Enemy[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Enemy t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

}
