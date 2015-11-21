using UnityEngine;
using System.Collections;

public class Tambourine : Weapon {

    [SerializeField]
    private float frequency = 10f;
    [SerializeField]
    private float magnitude = 0.5f;

	void Start () {
        OnStart();
        DestroyCount(selfDestructTime);
        UpgradeTambourine();
	}

    void Update()
    {
        RotateTowardsTarget(this.gameObject);
        ZigZag(frequency, magnitude);
    }

    public void UpgradeTambourine()
    {
       // UpgradeWeapon(); // this will need to change to be more precise
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
            this.transform.localScale *= 1.3f;
            coolDown *= 1.5f;
        }
        else
        {
            selfDestructTime *= 2f;
            this.transform.localScale *= 1.5f;
            coolDown *= 2f;
        }
    }
}
