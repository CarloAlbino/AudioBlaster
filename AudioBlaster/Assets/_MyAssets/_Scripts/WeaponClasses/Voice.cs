using UnityEngine;
using System.Collections;

public class Voice : Weapon {

    [SerializeField]
    private float maxProjectileSize;

    [SerializeField]
    private float expandRate;

	// Use this for initialization
	void Start () {
        OnStart();
        DestroyCount(selfDestructTime);
        UpgradeVoice();
	}
	
	// Update is called once per frame
	void Update () {
        SeekTarget();
        Expand(maxProjectileSize, 0, expandRate);
	}

    public void UpgradeVoice()
    {
        UpgradeWeapon(_player.GetCurrentWeaponLevel());
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);
        if (upgradeLevel < 1)
        {
            
        }
        else if (upgradeLevel < 2)
        {
            maxProjectileSize *= 1.2f;
            expandRate *= 1.2f;
            speed *= 1.2f;
        }
        else
        {
            maxProjectileSize *= 1.5f;
            expandRate *= 1.5f;
            speed *= 1.5f;
        }
    }
}
