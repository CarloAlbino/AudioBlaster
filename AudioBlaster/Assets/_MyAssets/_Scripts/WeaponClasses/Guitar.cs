﻿using UnityEngine;
using System.Collections;

public class Guitar : Weapon {

	// Use this for initialization
	void Start () {
        OnStart();
        DestroyCount(selfDestructTime); // 5f
        UpgradeGuitar();
	}
	
	// Update is called once per frame
	void Update () {
        SeekTarget();
        //MoveToTarget();
	}

    public void UpgradeGuitar()
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
            coolDown *= 0.75f;
        }
        else
        {
            coolDown *= 0.5f;
        }
    }
    
}
