using UnityEngine;
using System.Collections;

public class EnemyUpgrade : Enemy {

    bool hasDodged = false;
    bool hasCalledDodged = false;
	void Start () 
    {
        GetPlayerPosition();
        StartCoroutine(RandomShooting());
	}

	void Update () 
    {
        MoveToTarget();
    }

    #region AI
    public void AvoidProjectile(GameObject projectile)
    {
        if (!hasDodged)
        {
            Vector3 projDir = GetProjectileDir(projectile);
            Vector3 temp = transform.position;
            if (projDir.x < 0)   //Projectile coming from right
            {
                // Move Left
                float p = temp.x * 0.05f;
                temp.x += p;
            }
            else  // Projectile coming from left
            {
                // Move Right
                float p = temp.x * 0.05f;
                temp.x += p;
            }
            transform.position = temp;
            if (!hasCalledDodged)
            {
                StartCoroutine(DodgeTimer());
                hasCalledDodged = true;
            }
        }
    }

    protected IEnumerator DodgeTimer()
    {
        yield return new WaitForSeconds(0.5f);
        hasDodged = true;
        yield return new WaitForSeconds(1);
        hasDodged = false;
        hasCalledDodged = false;
    }

    protected Vector3 GetProjectileDir(GameObject projectile)
    {
        return projectile.transform.position - transform.position;
    }
    #endregion AI
}
