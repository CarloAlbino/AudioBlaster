using UnityEngine;
using System.Collections;

public class BossBarrierScript : MonoBehaviour {

    private EnemyBoss boss;

	// Use this for initialization
	void Start () {
        boss = GetComponentInParent<EnemyBoss>();
	}

//FIX THIS MAKE SURE A NUMBER CAN BE PASSED SOMEHOW
    public void BarrierDestroyed(int num)
    {
        boss.MinusBarrier(num);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            BarrierDestroyed(0);
            Destroy(this.gameObject);
        }
    }
}
