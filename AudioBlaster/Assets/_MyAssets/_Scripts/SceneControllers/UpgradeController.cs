using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeController : MonoBehaviour {

    private Player _player;

    public Text[] WeaponNames;
    public int[] WeaponNum;
    public Text Credits;
    public Button[] Weapon1Buttons;
    public Text[] Weapon1Levels;
    public Button[] Weapon2Buttons;
    public Text[] Weapon2Levels;
    public Button[] Weapon3Buttons;
    public Text[] Weapon3Levels;


	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        SetUpgradeOptions1();
        SetUpgradeOptions2();
        SetUpgradeOptions3();
        SetCredits();
	}

    void SetCredits()
    {
        Credits.text = "Credits: " + _player.GetUpgradeCredits();
        for (int i = 0; i < WeaponNames.Length; i++)
        {
            WeaponNames[i].text = _player.GetWeaponName(i);
        }
    }

    void SetUpgradeOptions1()
    {
        if(_player.GetCurrentWeaponLevel(0) == 0){
            Weapon1Levels[0].text = "Upgraded";
            Weapon1Buttons[0].interactable = false;
            Weapon1Levels[1].text = _player.GetWeapon1() + " Points to Upgrade";
            Weapon1Buttons[1].interactable = true;
            Weapon1Levels[2].text = "Locked";
            Weapon1Buttons[2].interactable = false;
        }else if (_player.GetCurrentWeaponLevel(0) == 1){
            Weapon1Levels[0].text = "Upgraded";
            Weapon1Buttons[0].interactable = false;
            Weapon1Levels[1].text = "Upgraded";
            Weapon1Buttons[1].interactable = false;
            Weapon1Levels[2].text = _player.GetWeapon1() + " Points to Upgrade";
            Weapon1Buttons[2].interactable = true;
        }else if (_player.GetCurrentWeaponLevel(0) == 2){
            Weapon1Levels[0].text = "Upgraded";
            Weapon1Buttons[0].interactable = false;
            Weapon1Levels[1].text = "Upgraded";
            Weapon1Buttons[1].interactable = false;
            Weapon1Levels[2].text = "Upgraded";
            Weapon1Buttons[2].interactable = false;
        }
    }

    void SetUpgradeOptions2()
    {
        if (_player.GetCurrentWeaponLevel(1) == 0)
        {
            Weapon2Levels[0].text = "Upgraded";
            Weapon2Buttons[0].interactable = false;
            Weapon2Levels[1].text = _player.GetWeapon2() + " Points to Upgrade";
            Weapon2Buttons[1].interactable = true;
            Weapon2Levels[2].text = "Locked";
            Weapon2Buttons[2].interactable = false;
        }
        else if (_player.GetCurrentWeaponLevel(1) == 1)
        {
            Weapon2Levels[0].text = "Upgraded";
            Weapon2Buttons[0].interactable = false;
            Weapon2Levels[1].text = "Upgraded";
            Weapon2Buttons[1].interactable = false;
            Weapon2Levels[2].text = _player.GetWeapon2() + " Points to Upgrade";
            Weapon2Buttons[2].interactable = true;
        }
        else if (_player.GetCurrentWeaponLevel(1) == 2)
        {
            Weapon2Levels[0].text = "Upgraded";
            Weapon2Buttons[0].interactable = false;
            Weapon2Levels[1].text = "Upgraded";
            Weapon2Buttons[1].interactable = false;
            Weapon2Levels[2].text = "Upgraded";
            Weapon2Buttons[2].interactable = false;
        }
    }

    void SetUpgradeOptions3()
    {
        if (_player.GetCurrentWeaponLevel(2) == 0)
        {
            Weapon3Levels[0].text = "Upgraded";
            Weapon3Buttons[0].interactable = false;
            Weapon3Levels[1].text = _player.GetWeapon3() + " Points to Upgrade";
            Weapon3Buttons[1].interactable = true;
            Weapon3Levels[2].text = "Locked";
            Weapon3Buttons[2].interactable = false;
        }
        else if (_player.GetCurrentWeaponLevel(2) == 1)
        {
            Weapon3Levels[0].text = "Upgraded";
            Weapon3Buttons[0].interactable = false;
            Weapon3Levels[1].text = "Upgraded";
            Weapon3Buttons[1].interactable = false;
            Weapon3Levels[2].text = _player.GetWeapon3() + " Points to Upgrade";
            Weapon3Buttons[2].interactable = true;
        }
        else if (_player.GetCurrentWeaponLevel(2) == 2)
        {
            Weapon3Levels[0].text = "Upgraded";
            Weapon3Buttons[0].interactable = false;
            Weapon3Levels[1].text = "Upgraded";
            Weapon3Buttons[1].interactable = false;
            Weapon3Levels[2].text = "Upgraded";
            Weapon3Buttons[2].interactable = false;
        }
    }
}
