using UnityEngine;
using System.Collections;

public class TriangleController : Weapon {

    [SerializeField]
    private GameObject projectile1;

    [SerializeField]
    private GameObject[] spawnPoints = new GameObject[6];

    [SerializeField]
    private float fireDelayTime = 1f;

    [SerializeField]
    private int loopsNum = 3;

	void Start () {
        _player = FindObjectOfType<Player>();
        StartCoroutine(ShootTriangle());
        UpgradeTriangle();
	}

    private IEnumerator ShootTriangle()
    {
        int i = 0;
        int j = 0;
        int k = 1;
        while (i < loopsNum)
        {
            if (i % 2 == 0)
                SpawnTriangleProjectile(j);
            else
                SpawnTriangleProjectile(k);
            yield return new WaitForSeconds(fireDelayTime);
            i++;
        }
        DestroyProjectile();
    }

    private void SpawnTriangleProjectile(int i)
    {
        for (; i < spawnPoints.Length; i += 2)
        {
            GameObject triangleProjectile = Instantiate(projectile1, spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
            triangleProjectile.GetComponent<Triangle>().Upgrade(upgradeLevel);
            triangleProjectile.transform.localRotation = spawnPoints[i].transform.localRotation;
        }
    }

    public void UpgradeTriangle()
    {
        UpgradeWeapon(_player.GetCurrentWeaponLevel());
        if (upgradeLevel == 1)
        {
            loopsNum = 5;
            coolDown *= 1.7f;
        }
        else if (upgradeLevel == 2)
        {
            loopsNum = 7;
            coolDown *= 2.3f;
        }
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);
    }
}
