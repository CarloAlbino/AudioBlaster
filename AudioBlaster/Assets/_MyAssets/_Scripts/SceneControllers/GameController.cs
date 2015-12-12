using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int numOfEnemies = 0;
    [SerializeField]
    private int maxEnemies = 25;

    public Button[] weaponButtons;

    public Text[] weaponButtonText;

    private int upgradePoints = 0;

    public int killsForPoint = 10;

    private int currentKillPoints = 0;

    public Image expBar;

    public Text upgradePointsText;

    public Text kills;

    public Text scoreText;

    public int score = 0;

    private WeaponSelectController _wc;

    private Player _player;

    public int timeToBoss = 90;

    public Text time;

    public GameObject bossPreFab;

    public Transform bossSpawnPoint;

    public GameObject upgradeMenu;

    private bool paused = false;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        _wc = FindObjectOfType<WeaponSelectController>();
        SetSelectedWeapons(_wc.GetWeapon1(), _wc.GetWeapon2(), _wc.GetWeapon3());
        _wc.DestroyWSController();
        _wc = null;
        //kills.text = "EXP:" + currentKillPoints;
        StartCoroutine(CountdownToBoss());
        scoreText.text = score.ToString();
        time.text = "Time to boss:\n" + timeToBoss + " s";
	}
	
	// Update is called once per frame
	void Update () {
        ColourButtons();
        upgradePointsText.text = "Upgrade Points: " + upgradePoints;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                CloseMenu();
            }
            else
            {
                PauseGame();
            }
        }
	}

    private void ColourButtons()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i == _player.GetCurrentlySelectedWeapon())
            {
                weaponButtons[i].interactable = false;
            }
            else
            {
                weaponButtons[i].interactable = true;
            }
        }
    }

    public int MaxEnemies()
    {
        //Debug.Log(maxEnemies);
        return maxEnemies;
    }

    public void CountKill(int n)
    {
        currentKillPoints += n;
        while (currentKillPoints >= killsForPoint)
        {
            currentKillPoints = currentKillPoints - killsForPoint;
            upgradePoints++;
        }
        //kills.text = "EXP:" + currentKillPoints;
        expBar.fillAmount = (float)currentKillPoints / (float)killsForPoint;
    }

    public int GetUpgradePoints()
    {
        return upgradePoints;
    }

    public void UseUpgradePoints(int n)
    {
        upgradePoints -= n;
    }

    public void SetSelectedWeapons(int w1, int w2, int w3)
    {
        _player.SetSelectedWeapons(w1, w2, w3);
        for (int i = 0; i < weaponButtonText.Length; i++)
        {
            weaponButtonText[i].text = _player.GetWeaponName(i);
        }
    }

    private IEnumerator CountdownToBoss()
    {
        yield return new WaitForSeconds(1);
        timeToBoss--;
        if (timeToBoss <= 0)
            SpawnBoss();
        else
            StartCoroutine(CountdownToBoss());
        time.text = "Time to boss:\n" + timeToBoss + " s";
    }

    private void SpawnBoss()
    {
        Instantiate(bossPreFab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        maxEnemies = 1;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        upgradeMenu.SetActive(true);
        paused = true;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        upgradeMenu.SetActive(false);
        paused = false;
    }

    public bool GetPaused()
    {
        return paused;
    }

    public void AddScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }

    public void QuitGame()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }

}
