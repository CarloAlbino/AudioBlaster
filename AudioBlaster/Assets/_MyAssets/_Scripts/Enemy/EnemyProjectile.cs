using UnityEngine;
using System.Collections;

public class EnemyProjectile : Weapon {

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        target = _player.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Call damage on other
            other.gameObject.GetComponent<Player>().SetHealth(damage);
            DestroyProjectile();
        }

        if (other.CompareTag("Projectile"))
        {
            DestroyProjectile();
        }
    }
}
