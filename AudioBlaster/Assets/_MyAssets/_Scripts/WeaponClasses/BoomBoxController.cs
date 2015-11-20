using UnityEngine;
using System.Collections;

public class BoomBoxController : Weapon {

    [SerializeField]
    private GameObject[] dancePoints = new GameObject[4];

    [SerializeField]
    private GameObject boomBoxProjectile;

    [SerializeField]
    private GameObject spawnPoint;

	// Use this for initialization
	void Start () {
        OnStart();
        DestroyCount(selfDestructTime);
        UpgradeBoomBox();
        StartCoroutine(SpawnPosse());
	}

    private IEnumerator SpawnPosse()
    {
        int i = 0;

        while (i < dancePoints.Length)
        {
            Debug.Log(dancePoints[i].name);
            SpawnBro(dancePoints[i].transform.position);
            yield return new WaitForSeconds(0.1f);
            i++;
        }
    }

    private void SpawnBro(Vector3 target)
    {
        GameObject projectile = Instantiate(boomBoxProjectile, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<BoomBox>().NewTarget(target);
        projectile.GetComponent<BoomBox>().Upgrade(upgradeLevel);
        projectile.transform.parent = this.gameObject.transform;
    }

    public void UpgradeBoomBox()
    {
        UpgradeWeapon(_player.GetCurrentWeaponLevel());
        // set sprite to new projectile
        //this.GetComponent<SpriteRenderer>().sprite = projectile[upgradeLevel];
        // set damage done to new damage done
        damage *= (float)(upgradeLevel + 1);
    }
}
