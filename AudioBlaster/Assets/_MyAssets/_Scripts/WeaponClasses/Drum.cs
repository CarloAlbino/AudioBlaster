using UnityEngine;
using System.Collections;

public class Drum : Weapon {
    void Start()
    {
        OnStart();
        DestroyCount(selfDestructTime); // 0.75f
        UpgradeDrum();
    }

    public void UpgradeDrum()
    {
        UpgradeWeapon(_player.GetCurrentWeaponLevel()); // this will need to change to be more precise
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);

        if (upgradeLevel < 1)
        {
            
        }
        else if (upgradeLevel < 2)
        {
            selfDestructTime *= 1.5f;
        }
        else
        {
            selfDestructTime *= 2f;
        }
    }
}
