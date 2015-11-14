using UnityEngine;
using System.Collections;

public class Tambourine : Weapon {

    [SerializeField]
    private float frequency = 10f;
    [SerializeField]
    private float magnitude = 0.5f;

	void Start () {
        OnStart(selftDestructTime);
	}

    void Update()
    {
        RotateTowardsTarget(this.gameObject);
        ZigZag(frequency, magnitude);
    }
}
