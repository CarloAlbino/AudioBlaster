using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    public float L_Limit, R_Limit, T_Limit, B_Limit;
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < T_Limit)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > B_Limit)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > L_Limit)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < R_Limit)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
