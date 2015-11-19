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
        if (upgradeLevel < 1)
        {
            SeekTarget();
            RotateTowardsTarget(this.gameObject);
            ZigZag(frequency, magnitude);
        }
        else if (upgradeLevel < 2)
        {
            SeekTarget();
            RotateTowardsTarget(this.gameObject);
            ZigZag(frequency * 1.15f, magnitude * 1.15f);
        }
        else
        {
            SeekTarget();
            RotateTowardsTarget(this.gameObject);
            ZigZag(frequency * 1.25f, magnitude * 1.25f);
        }
	}

    public void UpdgradeViolin()
    {
        UpgradeWeapon();
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);
    }
}
