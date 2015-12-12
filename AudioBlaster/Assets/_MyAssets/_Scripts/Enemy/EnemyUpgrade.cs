using UnityEngine;
using System.Collections;

public class EnemyUpgrade : Enemy {

    bool hasDodged = false;
    bool hasCalledDodged = false;
    Vector3 temp;
    Vector3 projDir;
	void Start () 
    {
        playerObject = FindObjectOfType<Player>();
        StartCoroutine(RandomShooting());
	}

	void Update () 
    {
        if(!hasDodged)
            MoveToTarget();
        else
            transform.Translate(projDir * maxSpeed * 2 * Time.deltaTime);
        RotateTowardsPlayer();
    }

    #region AI
    public void AvoidProjectile(GameObject projectile)
    {
        if (!hasDodged)
        {
            projDir = GetProjectileDir(projectile);
            temp = transform.position.normalized;
            int rand = Random.Range(0, 1);
            if (rand < 1)//projDir.x < 0)   //Projectile coming from right
            {
                // Move Left
                temp.x *= -1;
                //float p = temp.x * 0.05f;
               // temp.x += p;
            }
            else  // Projectile coming from left
            {
                // Move Right
                temp.y *= -1;
               // float p = temp.x * 0.05f;
               // temp.x += p;
            }
            //temp *= 0.5f;
            //transform.position += temp;
            //transform.Translate(temp * maxSpeed * Time.deltaTime);
            if (!hasCalledDodged)
            {
                StartCoroutine(DodgeTimer());
                hasCalledDodged = true;
            }
        }
    }

    protected IEnumerator DodgeTimer()
    {
        //yield return new WaitForSeconds(0.5f);
        hasDodged = true;
        yield return new WaitForSeconds(1f);
        hasDodged = false;
        hasCalledDodged = false;
    }

    protected Vector3 GetProjectileDir(GameObject projectile)
    {
        //return projectile.transform.position - transform.position;
        return transform.position - projectile.transform.position;
    }
    #endregion AI
}
