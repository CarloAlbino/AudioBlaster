using UnityEngine;
using System.Collections;

public class EnemyRangeDetector : MonoBehaviour {

    private EnemyUpgrade parent;

	// Use this for initialization
	void Start () {
        parent = GetComponentInParent<EnemyUpgrade>();
        Debug.Log(parent.gameObject.name);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("Projectile enter");
            parent.AvoidProjectile(other.gameObject);
        }
    }
}
