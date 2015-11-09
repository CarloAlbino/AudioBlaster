using UnityEngine;
using System.Collections;

public class Guitar : Weapon {

    /// <summary>
    /// Holds sprite for projectile at each upgrade level.
    /// </summary>
    [SerializeField]
    private Sprite[] projectile;

    /// <summary>
    /// Damage done at each level.
    /// </summary>
    [SerializeField]
    private float[] damageDone;


	// Use this for initialization
	void Start () {
        OnStart();
	}
	
	// Update is called once per frame
	void Update () {
        SeekTarget();
        //MoveToTarget();
	}

    public void Updgrade()
    {
        UpgradeWeapon();
        // set sprite to new projectile
        // set damage done to new damage done
    }
    
}
