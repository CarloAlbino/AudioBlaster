using UnityEngine;
using System.Collections;

public class donotdestroy : MonoBehaviour {
    public static donotdestroy Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
