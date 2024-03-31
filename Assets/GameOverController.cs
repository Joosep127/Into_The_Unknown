using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{

    #region Singleton
    public static GameOverController Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    // public BameObject


    private void Start()
    {
        Invoke("Disable", .0001f);
    }
    public void SetActive(bool isActive)
    {
        // this.Enable();
        Invoke("Enable", 3.0f);
    }
}
