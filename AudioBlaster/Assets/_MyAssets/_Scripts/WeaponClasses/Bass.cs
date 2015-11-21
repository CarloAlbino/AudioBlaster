using UnityEngine;
using System.Collections;

public class Bass : Weapon {

    [SerializeField]
    private float maxProjectileSize;

    [SerializeField]
    private float expandRate;

    [SerializeField]
    private float minProjectileSize;

    [SerializeField]
    private float negExpandRate;

    [SerializeField]
    private float interval = 1f;

    private bool Expanded = false;

	// Use this for initialization
	void Start () {
        OnStart();
        DestroyCount(selfDestructTime);
        UpgradeBass();
        StartCoroutine(BassWave());
	}

    void Update()
    {
        ExpandCheck();
    }

    private IEnumerator BassWave(){
        Expanded = false;
        yield return new WaitForSeconds(interval);
        Expanded = true;
        yield return new WaitForSeconds(interval);
        StartCoroutine(BassWave());
    }

    private void ExpandCheck()
    {
        if (Expanded)
        {
            Expand(maxProjectileSize, minProjectileSize, negExpandRate);
        }
        else
        {
            Expand(maxProjectileSize, minProjectileSize, expandRate);
        }
    }

    public void UpgradeBass()
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
            negExpandRate *= 1.2f;
            expandRate *= 1.2f;
            coolDown *= 1.2f;
        }
        else
        {
            maxProjectileSize *= 1.5f;
            negExpandRate *= 1.5f;
            expandRate *= 1.5f;
            coolDown *= 1.5f;
        }
    }
}
