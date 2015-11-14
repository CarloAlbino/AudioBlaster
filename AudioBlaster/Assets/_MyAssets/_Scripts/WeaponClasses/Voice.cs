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
        Expand(maxProjectileSize, 0, expandRate);
	}
}
