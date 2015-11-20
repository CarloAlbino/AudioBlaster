using UnityEngine;
using System.Collections;

public class WeaponSelectController : MonoBehaviour {

    public int w1 = 0;
    public int w2 = 1;
    public int w3 = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int GetWeapon1()
    {
        return w1;
    }
    public int GetWeapon2()
    {
        return w2;
    }
    public int GetWeapon3()
    {
        return w3;
    }

    public void DestroyWSController()
    {
        Destroy(this.gameObject);
    }
}
