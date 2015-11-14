using UnityEngine;
using System.Collections;

public class Violin : Weapon {

    [SerializeField]
    private float frequency = 10f;
    [SerializeField]
    private float magnitude = 0.5f;

	// Use this for initialization
	void Start () {
        OnStart(selftDestructTime);
	}
	
	// Update is called once per frame
	void Update () {
        /*UpdateMousePositionTarget();
        RotateTowardsTarget(this.gameObject);
        if(Input.GetMouseButtonUp(0)){
            //DestroyCount(1.0f);
           DestroyProjectile();
        }*/
        SeekTarget();
        //MoveToTarget();
        RotateTowardsTarget(this.gameObject);
        ZigZag(frequency, magnitude);
	}
}
