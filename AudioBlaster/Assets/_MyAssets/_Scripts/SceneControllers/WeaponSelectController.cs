using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponSelectController : MonoBehaviour {

    // Buttons
    [SerializeField]
    private Button[] longRange;
    [SerializeField]
    private Button[] closeRange;
    [SerializeField]
    private Button[] special;

    // Button Text
    [SerializeField]
    private Text[] longRangeText;
    [SerializeField]
    private Text[] closeRangeText;
    [SerializeField]
    private Text[] specialText;

    // Selected Weapons
    private int w1 = -1;
    private int w2 = -1;
    private int w3 = -1;

    // Play Button
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Text playButtonText;

	void Start () {
        DontDestroyOnLoad(this.gameObject);
        ResetButtons(longRange, longRangeText);
        ResetButtons(closeRange, closeRangeText);
        ResetButtons(special, specialText);
        // Set play buttons to not clickable until weapons are picked.
        playButton.interactable = false;
        playButtonText.text = "Choose Weapons";
        SetButtons(special, specialText, -1);
        SetButtons(closeRange, closeRangeText, -1);
        SetButtons(longRange, longRangeText, -1);
	}

    #region Public Functions

    public void ChoseLRWeapon(int buttonNum)
    {
        SetButtons(longRange, longRangeText, buttonNum);
        w1 = buttonNum;
        if (WeaponsSelected())
        {
            playButton.interactable = true;
            playButtonText.text = "PLAY >>";
        }
    }

    public void ChoseCRWeapon(int buttonNum)
    {
        SetButtons(closeRange, closeRangeText, buttonNum);
        w2 = buttonNum + 3;
        if (WeaponsSelected())
        {
            playButton.interactable = true;
            playButtonText.text = "PLAY >>";
        }
    }

    public void ChoseSWeapon(int buttonNum)
    {
        SetButtons(special, specialText, buttonNum);
        w3 = buttonNum + 6;
        if (WeaponsSelected())
        {
            playButton.interactable = true;
            playButtonText.text = "PLAY >>";
        }
    }

    public int GetWeapon1()
    {
        return w1;
    }
    public int GetWeapon2()
    {
        return w2;
    }
    public int GetWeapon3()
    {
        return w3;
    }

    public void DestroyWSController()
    {
        Destroy(this.gameObject);
    }

    public void GoToNextLevel()
    {
        Application.LoadLevel(2);
    }

    #endregion Public Functions

    #region Private Funtions

    private bool WeaponsSelected()
    {
        if(w1 > -1 && w2 > -1 && w3 > -1)
            return true;
        else
            return false;
    }

    private void SetButtons(Button[] _bArray, Text[] _tArray, int i)
    {
        for (int j = 0; j < _tArray.Length; j++)
        {
            if (j == i)
            {
                _tArray[j].text = "Selected";
                _bArray[j].image.color = Color.red;
            }
            else
            {
                _tArray[j].text = "Click to Select";
                _bArray[j].image.color = Color.white;
            }
        }
    }
    
    private void ResetButtons(Button[] _bArray, Text[] _tArray)
    {
        for (int i = 0; i < _tArray.Length; i++)
        {
            _tArray[i].text = "";
            _bArray[i].image.color = Color.white;
        }
    }

    #endregion Private Funtions

}
