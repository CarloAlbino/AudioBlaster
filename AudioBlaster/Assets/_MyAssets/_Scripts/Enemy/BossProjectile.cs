using UnityEngine;
using System.Collections;

public class BossProjectile : MonoBehaviour {

    public float speed;
    public float timer;

	// Use this for initialization
	void Start () {
        StartCoroutine(DestroySelf());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
