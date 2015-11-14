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
        OnStart(selftDestructTime);
        StartCoroutine(BassWave());
	}

    void Update()
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

    private IEnumerator BassWave(){
        Expanded = false;
        yield return new WaitForSeconds(interval);
        Expanded = true;
        yield return new WaitForSeconds(interval);
        StartCoroutine(BassWave());
    }
}
