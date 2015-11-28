using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

    public float speed;
    public float timer;

	// Use this for initialization
	void Start () {
        Invoke("DestroySelf", timer);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

    void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
