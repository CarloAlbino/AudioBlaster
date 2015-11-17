using UnityEngine;
using System.Collections;

public class BoomBox : BoomBoxController {

    [SerializeField]
    private int numOfHits = 3;

	// Use this for initialization
	void Start () {
        //OnStart(selftDestructTime);
	}
	
	// Update is called once per frame
	void Update () {
        MoveToTarget();
	}

    public void TakeHit()
    {
        numOfHits--;
        if (numOfHits <= 0)
        {
            DestroyProjectile();
        }
    }
}
