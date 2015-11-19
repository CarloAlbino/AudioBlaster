using UnityEngine;
using System.Collections;

public class Voice : Weapon {

    [SerializeField]
    private float maxProjectileSize;

    [SerializeField]
    private float expandRate;

	// Use this for initialization
	void Start () {
        OnStart(selftDestructTime);
	}
	
	// Update is called once per frame
	void Update () {
        SeekTarget();
        if (upgradeLevel < 1)
        {
            Expand(maxProjectileSize, 0, expandRate);
        }
        else if (upgradeLevel < 2)
        {
            Expand(maxProjectileSize * 1.2f, 0, expandRate * 1.2f);
            speed *= 1.2f;
        }
        else
        {
            Expand(maxProjectileSize * 1.5f, 0, expandRate * 1.5f);
            speed *= 1.5f;
        }
	}

    public void UpdgradeVoice()
    {
        UpgradeWeapon();
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);
    }
}
