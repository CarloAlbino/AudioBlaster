using UnityEngine;
using System.Collections;

public class Guitar : Weapon {

	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        SeekTarget();
        //MoveToTarget();
	}
}
