using UnityEngine;
using System.Collections;

public class BossCollisions : MonoBehaviour {
    private EnemyBoss _controller;

    void Start()
    {
        _controller = GetComponent<EnemyBoss>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Drum>())
        {
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Guitar>())
        {
            other.GetComponent<Guitar>().DestroyProjectile();
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Rap>())
        {
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Violin>())
        {
            other.GetComponent<Violin>().DestroyProjectile();
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Voice>())
        {
            other.GetComponent<Voice>().DestroyProjectile();
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Tambourine>())
        {
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Bass>())
        {
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<Triangle>())
        {
            other.GetComponent<Triangle>().DestroyProjectile();
            _controller.SetHealth(-5f);
        }
        if (other.GetComponent<BoomBox>())
        {
            other.GetComponent<BoomBox>().TakeHit();
            _controller.SetHealth(-5f);
        }
    }
}
