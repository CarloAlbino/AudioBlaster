using UnityEngine;
using System.Collections;

public class BossBarrierScript : MonoBehaviour {

    private EnemyBoss boss;
    private int barrierNum;

	// Use this for initialization
	void Start () {
        boss = FindObjectOfType<EnemyBoss>();
	}

    public void SetBarrierNum(int n)
    {
        //Debug.Log("Set Barrier " + n);
        barrierNum = n;
    }

    public void BarrierDestroyed()
    {
        boss.MinusBarrier(barrierNum);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            other.GetComponent<Weapon>().DestroyProjectile();
            BarrierDestroyed();
            Destroy(this.gameObject);
        }
    }
}
