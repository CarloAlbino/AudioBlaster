using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour
{

    #region Public Methods

    /// <summary>
    /// Loads the level that is passed to this function.
    /// </summary>
    /// <param name="levelNum">The number of the level to be loaded.</param>
    public void LoadNewLevel(int levelNum)
    {
        Application.LoadLevel(levelNum);
    }

    /// <summary>
    /// Exits the application. 
    /// </summary>
    public void ExitGame()
    {
        // Maybe put a comfirmation before just quitting.
        Application.Quit();
    }

    #endregion Public Methods

}
