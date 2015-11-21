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
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if(other.GetComponent<Guitar>())
        {
            other.GetComponent<Guitar>().DestroyProjectile();
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Rap>())
        {
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Violin>())
        {
            other.GetComponent<Violin>().DestroyProjectile();
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Voice>())
        {
            other.GetComponent<Voice>().DestroyProjectile();
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Tambourine>())
        {
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Bass>())
        {
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<Triangle>())
        {
            other.GetComponent<Triangle>().DestroyProjectile();
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }
        if (other.GetComponent<BoomBox>())
        {
            other.GetComponent<BoomBox>().TakeHit();
            _controller.numOfEnemies--;
            _controller.CountKill(1);
            Destroy(this.gameObject);
        }

    }
}
