using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int numOfEnemies = 0;
    [SerializeField]
    private int maxEnemies = 25;

    public Button[] weaponButtons;

    public Text[] weaponButtonText;

    private WeaponSelectController _wc;

    private Player _player;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
        _wc = FindObjectOfType<WeaponSelectController>();
        SetSelectedWeapons(_wc.GetWeapon1(), _wc.GetWeapon2(), _wc.GetWeapon3());
        _wc.DestroyWSController();
        _wc = null;
	}
	
	// Update is called once per frame
	void Update () {
        ColourButtons();
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
        return maxEnemies;
    }

    public void SetSelectedWeapons(int w1, int w2, int w3)
    {
        _player.SetSelectedWeapons(w1, w2, w3);
        for (int i = 0; i < weaponButtonText.Length; i++)
        {
            weaponButtonText[i].text = _player.GetWeaponName(i);
        }
    }

}
