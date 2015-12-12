using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour {

    public Image healthBack;
    public Image health;
    public Image end1;
    public Image end2;

    public void ShowHealthBar()
    {
        healthBack.gameObject.SetActive(true);
        health.gameObject.SetActive(true);
        end1.gameObject.SetActive(true);
        end2.gameObject.SetActive(true);
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
