using UnityEngine;
using System.Collections;

public class Triangle : Weapon {

    [SerializeField]
    private float maxProjectileSize;

    [SerializeField]
    private float expandRate;

    [SerializeField]
    private float frequency = 10f;

    [SerializeField]
    private float magnitude = 0.5f;

	// Use this for initialization
	void Start () {
        OnStart(selfDestructTime);
	}
	
	// Update is called once per frame
	void Update () {
        MoveForward();
        if (upgradeLevel < 1){
            // First level
        }
        else if (upgradeLevel < 2)
        {
            // Second level
            Expand(maxProjectileSize, 0, expandRate);
        }
        else
        {
            // Third level
            Expand(maxProjectileSize, 0, expandRate);
            ZigZag(frequency, magnitude);
        }
	}

    public void Upgrade(int level)
    {
        upgradeLevel = level;
        if(upgradeLevel > 1)
            expandRate *= 2;
    }
}
