using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int numOfEnemies = 0;
    [SerializeField]
    private int maxEnemies = 25;

    public Button[] weaponButtons;

    private Player _player;

	// Use this for initialization
	void Start () {
        _player = FindObjectOfType<Player>();
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

}
