using UnityEngine;
using System.Collections;

public class BossRangeDetector : MonoBehaviour {

    private EnemyBoss parent;

    // Use this for initialization
    void Start()
    {
        parent = GetComponentInParent<EnemyBoss>();
        //Debug.Log(parent.gameObject.name);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            //Debug.Log("Projectile enter");
            int random = Random.Range(0, 10);
            if(random < 4)
                parent.DeployMinion(other.gameObject.transform);
        }
    }
}
