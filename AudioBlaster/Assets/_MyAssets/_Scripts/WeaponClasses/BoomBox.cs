using UnityEngine;
using System.Collections;

public class BoomBox : Weapon {

    [SerializeField]
    private int numOfHits = 3;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        damage = 10;
        upgradeLevel = 0;
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

    public void Upgrade(int level)
    {
        upgradeLevel = level;
        numOfHits += upgradeLevel;
    }
}
