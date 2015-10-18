using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    [SerializeField]
    private float maxSpeed = 10.0f;

    [SerializeField]
    private float timeToTarget = 0.5f;

    [SerializeField]
    private float radiusOfTarget = 2.0f;

    private Vector3 _player;

    private Vector3 velocity;
	// Use this for initialization
	void Start () {
        GetPlayerPosition();
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}

    private void GetPlayerPosition()    // Not effecient for this particular enemy, should be called every frame when the player is moving.
    {
        _player = FindObjectOfType<Player>().transform.position;
    }

    private void GetVelocity()
    {
        velocity = _player - transform.position;
    }

    private void MoveToTarget()
    {
        GetVelocity();
        if (velocity.magnitude < radiusOfTarget)
        {

        }
        else
        {
            velocity /= timeToTarget;

            if (velocity.magnitude > maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            this.transform.Translate(velocity * maxSpeed * Time.deltaTime);
        }

    }
}
