using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

    [SerializeField]
    private float health;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private GameObject barrier;

    [SerializeField]
    private Transform[] barrierPoints;

    private GameObject[] barrierArray;

    [SerializeField]
    private Transform projectileSpawnPoint;

    [SerializeField]
    private GameObject barrage;

    [SerializeField]
    private GameObject minion;

    [SerializeField]
    private int maxMinions;

    private int minionCount = 0;

    [SerializeField]
    private Transform minionSpawnPoint;

    private Transform minionTarget;

    private Player _player;

    private bool canDecide = true;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        barrierArray =  new GameObject[barrierPoints.Length];
        StartCoroutine(CoolDown(Random.Range(6.5f, 8.5f)));
	}
	
	// Update is called once per frame
	void Update () {
        RotateTowardsTarget();
        MakeDecision();
	}

    void MakeDecision()
    {
        if (canDecide)
        {
            int randomDecision = Random.Range(0, 100);

            if (health < (maxHealth/2))
            {
                if (randomDecision < 55)
                {
                    DeployBarrier();
                }
                else
                {
                    StartCoroutine(FireBarrage());
                }
            }
            else
            {
                if (randomDecision < 35)
                {
                    DeployBarrier();
                }
                else
                {
                    StartCoroutine(FireBarrage());
                }
            }
        }
    }

    IEnumerator CoolDown(float cooldownTime)
    {
        canDecide = false;
        yield return new WaitForSeconds(cooldownTime);
        canDecide = true;
    }

    void RotateTowardsTarget()
    {
        projectileSpawnPoint.transform.rotation = Quaternion.LookRotation(Vector3.forward, _player.transform.position - transform.position);
    }

    public void DeployMinion(Transform target)
    {
        if (minionCount < maxMinions)
        {
            GameObject m = Instantiate(minion, minionSpawnPoint.position, minionSpawnPoint.rotation) as GameObject;
            //Set the target for the new minion
            //m.GetComponent<EnemyBossMinion>().SetTarget(target.position);
            m.GetComponent<Enemy>().NewTarget(target.position);
            minionCount++;
        }
    }

    public void DecreaseMinionCount()
    {
        minionCount--;
        if (minionCount <= 0)
            minionCount = 0;
    }

    IEnumerator FireBarrage()
    {
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        StartCoroutine(CoolDown(Random.Range(6.5f,8.5f)));
    }

    void DeployBarrier()
    {
        int randomNum;

        do
        {
            randomNum = Random.Range(0, barrierPoints.Length);
        }
        while (barrierArray[randomNum] != null);

        if (barrierArray[randomNum] == null)
        {
            barrierArray[randomNum] = Instantiate(barrier, barrierPoints[randomNum].position, barrierPoints[randomNum].rotation) as GameObject;
            StartCoroutine(CoolDown(Random.Range(6.5f, 8.5f)));
        }
    }

    void SetHealth(float inc)
    {
        health += inc;

        if (health <= 0)
            health = 0;

        if (health > maxHealth)
            health = maxHealth;
    }

}
