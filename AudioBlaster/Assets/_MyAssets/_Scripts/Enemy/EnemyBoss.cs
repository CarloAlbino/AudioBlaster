using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyBoss : MonoBehaviour {

    [SerializeField]
    private float health;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private BossHealthBar bossHealthObject;

    [SerializeField]
    private Image bossHealth;

    [SerializeField]
    private GameObject barrier;

    [SerializeField]
    private Transform[] barrierPoints;

    private GameObject[] barrierArray;

    private int[] barrierCount;

    [SerializeField]
    private int maxBarriers = 3;

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

    public Transform bossSpot;

    public float timeToTarget;

    public float maxSpeed;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        barrierArray =  new GameObject[barrierPoints.Length];
        barrierCount = new int[barrierPoints.Length];
        StartCoroutine(CoolDown(Random.Range(1.5f, 6.5f)));
        bossHealthObject = FindObjectOfType<BossHealthBar>();
        bossHealthObject.ShowHealthBar();
        bossHealth = bossHealthObject.GetHealthBar();
        bossSpot = GameObject.Find("BossTarget").transform;
	}
	
	// Update is called once per frame
	void Update () {
        RotateTowardsTarget();
        MakeDecision();
        MoveToTarget();
	}

    void MakeDecision()
    {
        if (canDecide)
        {
            int randomDecision = Random.Range(0, 100);

            if (health < (maxHealth/2))
            {
                if (randomDecision < 45)
                {
                    DeployBarrier();
                }
                else
                {
                    StartCoroutine(FireBarrage(1.5f, 6.5f));
                }
            }
            else if(health > (maxHealth/2))
            {
                if (randomDecision < 30)
                {
                    DeployBarrier();
                }
                else
                {
                    StartCoroutine(FireBarrage(1.5f, 6.5f));
                }
            }
            else
            {
                StartCoroutine(FireBarrage(1.5f, 3.0f));
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

    IEnumerator FireBarrage(float min, float max)
    {
        StartCoroutine(CoolDown(Random.Range(min, max)));
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(barrage, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
    }

    void DeployBarrier()
    {
        StartCoroutine(CoolDown(Random.Range(1.5f, 6.5f)));
        int randomNum;

        randomNum = Random.Range(0, barrierPoints.Length);
        if (barrierCount[randomNum] > 0)
        {
            for (int i = 0; i < barrierCount.Length; i++)
            {
                if (barrierCount[i] == 0)
                {
                    randomNum = i;
                    break;
                }
            }
        }

        if (barrierArray[randomNum] == null)
        {
            barrierArray[randomNum] = Instantiate(barrier, barrierPoints[randomNum].position, barrierPoints[randomNum].rotation) as GameObject;
            //barrierArray[randomNum].transform.parent = this.gameObject.transform;
            barrierCount[randomNum] = 1;
            barrierArray[randomNum].GetComponent<BossBarrierScript>().SetBarrierNum(randomNum);
        }
    }

    public void MinusBarrier(int n)
    {
        Debug.Log("REmoving Barrier " + n);
        barrierCount[n] = 0;
    }

    public void SetHealth(float inc)
    {
        health += inc;

        if (health <= 0)
        {
            health = 0;
            Destroy(this.gameObject);
        }

        if (health > maxHealth)
            health = maxHealth;

        bossHealth.fillAmount = health / maxHealth;
    }

    private void MoveToTarget()
    {
        Vector3 velocity = bossSpot.position - transform.position;
        velocity /= timeToTarget;

        if (velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }
        this.transform.Translate(velocity * maxSpeed * Time.deltaTime);
    }

}
