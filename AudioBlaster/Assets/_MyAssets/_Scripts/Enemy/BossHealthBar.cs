using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public Image healthBack;
    public Image health;

    public void ShowHealthBar()
    {
        healthBack.gameObject.SetActive(true);
        health.gameObject.SetActive(true);
    }

    public Image GetHealthBar()
    {
        return health;
    }

    public void DestroyHealthBar()
    {
        Destroy(this.gameObject);
    }
}
