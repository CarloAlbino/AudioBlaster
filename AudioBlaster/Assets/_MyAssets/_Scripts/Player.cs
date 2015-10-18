using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    #region Variables

    /// <summary>
    /// Array for holding all the types of weapon projectiles.
    /// </summary>
    [SerializeField]
    private GameObject[] weaponProjectiles;

    /// <summary>
    /// The 3 selected weapons for the current try of the game.
    /// </summary>
    [SerializeField]
    private int[] selectedWeapons;

    /// <summary>
    /// The weapon that will fire when the fire button is pressed.
    /// </summary>
    [SerializeField]
    private int currentlySelectedWeapon = 0;

    /// <summary>
    /// Save the position of the last spot that was clicked.
    /// </summary>
    private Vector3 mouseClickPosition;

    #endregion Variables

    #region Monobehaviour

    // Update is called once per frame
	void Update () {
        SwitchWeapon();
        FireWeapon();
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
            Instantiate(weaponProjectiles[currentlySelectedWeapon], this.gameObject.transform.position, Quaternion.identity);
            SetMouseClickPosition();
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

    #endregion Public Methods

}
