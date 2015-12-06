using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverController : MonoBehaviour {
    public Text score;
    public Text verdict;
	// Use this for initialization
	void Start () {
        score.text = "Score: " + PlayerPrefs.GetInt("Score");
        verdict.text = PlayerPrefs.GetString("Verdict");
	}

    public void MainMenu()
    {
        Time.timeScale = 1;
        Application.LoadLevel(0);
    }
}
