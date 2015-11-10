using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {
    private GameController _controller;

    void Start()
    {
        _controller = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Drum>())
        {
            _controller.numOfEnemies--;
            Destroy(this.gameObject);
        }
        if(other.GetComponent<Guitar>())
        {
            other.GetComponent<Guitar>().DestroyProjectile();
            _controller.numOfEnemies--;
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Rap>())
        {
            _controller.numOfEnemies--;
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Violin>())
        {
            _controller.numOfEnemies--;
            Destroy(this.gameObject);
        }
    }
}
