using UnityEngine;
using System.Collections;

public class EnemyBossMinion : MonoBehaviour
{
    bool gotTarget = false;
    Vector3 target;
    public float maxSpeed;
    public float timeToTarget;
	
	// Update is called once per frame
	void Update () {
        if (gotTarget)
            MoveToTarget();
	}

    public void SetTarget(Vector3 pos)
    {
        Debug.Log("Target Set");
        target = pos;
        gotTarget = true;
        Debug.Log(gotTarget);
    }

    void MoveToTarget()
    {
        Vector3 dir = target - transform.position;

        dir /= timeToTarget;

        if (dir.magnitude > maxSpeed)
        {
            dir.Normalize();
            dir *= maxSpeed;
        }
        this.transform.Translate(dir * maxSpeed * Time.deltaTime);
    }
}
