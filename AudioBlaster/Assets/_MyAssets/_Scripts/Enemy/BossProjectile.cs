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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Call damage on other
            other.gameObject.GetComponent<Player>().SetHealth(-10);
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
