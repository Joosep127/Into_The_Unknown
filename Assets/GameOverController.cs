using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        StartCoroutine(SceneController.Instance.LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
