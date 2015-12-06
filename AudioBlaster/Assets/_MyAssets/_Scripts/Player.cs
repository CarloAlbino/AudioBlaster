using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{

    #region Variables

    /// <summary>
    /// Player's Health.
    /// </summary>
    [SerializeField]
    private float playerHealth;

    /// <summary>
    /// Max player health.
    /// </summary>
    [SerializeField]
    private float maxHealth;

    /// <summary>
    /// Reference to the health bar.
    /// </summary>
    [SerializeField]
    private Image healthBar;

    /// <summary>
    /// Array for holding all the types of weapon projectiles.
    /// </summary>
    [SerializeField]
    public GameObject[] weaponProjectiles;

    /// <summary>
    /// The 3 selected weapons for the current try of the game.
    /// </summary>
    [SerializeField]
    public int[] selectedWeapons = new int[3];

    /// <summary>
    /// The upgrade level for each of the selected weapons.
    /// </summary>
    private int[] selectedWeaponLevel = new int[3];

    /// <summary>
    /// Cooldown for each of the selected weapons.
    /// </summary>
    private float[] weaponCoolDown = new float[3];

    /// <summary>
    /// Current cooldown time for each of the used weapons.
    /// </summary>
    private float[] currentCoolDown = new float[3];

    [SerializeField]
    private Image[] coolDownClocks = new Image[3];

    /// <summary>
    /// Can each of the weapons be fired?
    /// </summary>
    private bool[] canFire = new bool[3];

    /// <summary>
    /// The weapon that will fire when the fire button is pressed.
    /// </summary>
    [SerializeField]
    private int currentlySelectedWeapon = 0;

    /// <summary>
    /// Save the position of the last spot that was clicked.
    /// </summary>
    private Vector3 mouseClickPosition;

    public GameController _gc;

    #endregion Variables

    #region Monobehaviour

    void Start()
    {
        _gc = FindObjectOfType<GameController>();
        SetUpgradeLevels();
        for (int i = 0; i < canFire.Length; i++)
        {
            canFire[i] = true;
            weaponCoolDown[i] = weaponProjectiles[selectedWeapons[i]].GetComponent<Weapon>().GetCooldownTime();
            currentCoolDown[i] = 0;
        }
        playerHealth = maxHealth;
    }

	void Update () {
        if (!_gc.GetPaused())
        {
            SwitchWeapon();
            FireWeapon();
            Death();
        }
        /*if (Input.GetKeyDown(KeyCode.A))
        {
            UpgradeWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            UpgradeWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            UpgradeWeapon(2);
        }*/
	}

    #endregion Monobehaviour

    #region Private Methods

    /// <summary>
    /// Fire the selected weapon when the left mouse button is clicked.
    /// </summary>
    private void FireWeapon()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canFire[currentlySelectedWeapon])
            {
                Instantiate(weaponProjectiles[selectedWeapons[currentlySelectedWeapon]], this.gameObject.transform.position, Quaternion.identity);
                SetMouseClickPosition();
                StartCoroutine(StartCooldown());
            }
        }
    }

    private void SetMouseClickPosition()
    {
        mouseClickPosition = Input.mousePosition;
        mouseClickPosition = Camera.main.ScreenToWorldPoint(mouseClickPosition);
        mouseClickPosition.z = 0;
        mouseClickPosition.Normalize();
    }

    /// <summary>
    /// Switches the what weapon will fire when the TAB key is pressed.
    /// </summary>
    private void SwitchWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (currentlySelectedWeapon < selectedWeapons.Length - 1)
                currentlySelectedWeapon++;
            else
                currentlySelectedWeapon = 0;
        }
    }

    private void SetUpgradeLevels()
    {
        for (int i = 0; i < selectedWeaponLevel.Length; i++)
        {
            selectedWeaponLevel[i] = 0;
        }
    }

    private IEnumerator StartCooldown()
    {
        int i = currentlySelectedWeapon;
        canFire[i] = false;
        currentCoolDown[i] = weaponCoolDown[i];
        coolDownClocks[i].fillAmount = weaponCoolDown[i];
        while (currentCoolDown[i] > 0)
        {
            yield return new WaitForSeconds(0.01f);
            currentCoolDown[i] -= 0.01f;
            float percentage = currentCoolDown[i]/weaponCoolDown[i];
            coolDownClocks[i].fillAmount = percentage;
        }
        canFire[i] = true;
        coolDownClocks[i].fillAmount = 0;
    }

    private void Death()
    {
        if (playerHealth <= 0)
        {
            PlayerPrefs.SetInt("Score", _gc.score);
            PlayerPrefs.SetString("Verdict", "You Lose!");
            Application.LoadLevel(3);
        }
    }

    #endregion Private Methods

    #region Public Methods

    /// <summary>
    /// Switches what weapon will fire to the specified number.
    /// </summary>
    /// <param name="w">Weapon to be selected.</param>
    public void SwitchWeapon(int w)
    {
        if (w >= 0 && w <= selectedWeapons.Length)
            currentlySelectedWeapon = w;
        else
            w = 0;
    }

    /// <summary>
    /// Sets the 3 weapons that can be used by the player.  This would be called by another script that knows the choices.
    /// </summary>
    /// <param name="firstWeapon">First weapon slot.</param>
    /// <param name="secondWeapon">Second weapon slot.</param>
    /// <param name="thirdWeapon">Third weapon slot.</param>
    public void SetSelectedWeapons(int firstWeapon, int secondWeapon, int thirdWeapon)
    {
        selectedWeapons[0] = firstWeapon;
        selectedWeapons[1] = secondWeapon;
        selectedWeapons[2] = thirdWeapon;
    }

    /// <summary>
    /// Returns the currently chosen weapon.
    /// </summary>
    /// <returns>The weapon slot that is currently being used.</returns>
    public int GetCurrentlySelectedWeapon()
    {
        return currentlySelectedWeapon;
    }

    /// <summary>
    /// Returns the last position clicked my the mouse.
    /// </summary>
    /// <returns></returns>
    public Vector3 GetMouseClickPosition()
    {
        return mouseClickPosition;
    }

    /// <summary>
    /// Upgrade a weapon.
    /// </summary>
    /// <param name="weaponNum">The number of the weapon to upgrade.</param>
    /// <param name="newLevel">The upgrade level the weapon will be at.</param>
    public void SetUpgradeWeapon(int weaponNum, int newLevel)
    {
        selectedWeaponLevel[weaponNum] = newLevel;
    }

    /// <summary>
    /// Get the upgrade level of the currently selected weapon.
    /// </summary>
    /// <returns>The upgrade level.</returns>
    public int GetCurrentWeaponLevel()
    {
        return selectedWeaponLevel[currentlySelectedWeapon];
    }

    public int GetCurrentWeaponLevel(int i)
    {
        return selectedWeaponLevel[i];
    }

    public string GetWeaponName(int weaponNum)
    {
        return weaponProjectiles[selectedWeapons[weaponNum]].GetComponent<Weapon>().weaponName;
    }

    public void UpgradeWeapon(int weaponNum)
    {
        int points = weaponProjectiles[selectedWeapons[weaponNum]].GetComponent<Weapon>().GetPointsNeeded();
        if (points > 0 && points <= _gc.GetUpgradePoints())
        {
            selectedWeaponLevel[weaponNum]++;
            _gc.UseUpgradePoints(points);
        }
    }

    public void SetHealth(float healthInc)
    {
        playerHealth += healthInc;
        if (playerHealth < 0)
            playerHealth = 0;
        if (playerHealth > maxHealth)
            playerHealth = maxHealth;
        healthBar.fillAmount += healthInc / maxHealth;
    }


    public int GetUpgradeCredits()
    {
        return _gc.GetUpgradePoints();
    }

    public int GetWeapon1()
    {
        return weaponProjectiles[selectedWeapons[0]].GetComponent<Weapon>().GetPointsNeeded();
    }
    public int GetWeapon2()
    {
        return weaponProjectiles[selectedWeapons[1]].GetComponent<Weapon>().GetPointsNeeded();
    }
    public int GetWeapon3()
    {
        return weaponProjectiles[selectedWeapons[2]].GetComponent<Weapon>().GetPointsNeeded();
    }

    #endregion Public Methods

}
