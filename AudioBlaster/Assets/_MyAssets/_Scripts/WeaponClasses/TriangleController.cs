using UnityEngine;
using System.Collections;

public class TriangleController : Weapon {

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private GameObject[] spawnPoints = new GameObject[6];

    [SerializeField]
    private float fireDelayTime = 1f;

    [SerializeField]
    private int loopsNum = 3;

	void Start () {
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
            GameObject triangleProjectile = Instantiate(projectile, spawnPoints[i].transform.position, Quaternion.identity) as GameObject;
            triangleProjectile.transform.localRotation = spawnPoints[i].transform.localRotation;
        }
    }

    private void UpgradeTriangle()
    {
        if (upgradeLevel == 1)
        {
            loopsNum = 5;
        }
        else if (upgradeLevel == 2)
        {
            loopsNum = 7;
        }
    }
}
