using UnityEngine;
using System.Collections;

public class Violin : Weapon {

	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateMousePositionTarget();
        RotateTowardsTarget(this.gameObject);
        if(Input.GetMouseButtonUp(0)){
            //DestroyCount(1.0f);
           DestroyProjectile();
        }
	}
}
