using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [Header("Meau Buttons")]

    [SerializeField] private Button newGameButton;
    [SerializeField] private Button continuteGameButton;

    public GameObject mainmenu;
    public GameObject Levels;


    public void OnNewGameClicked()
    {
        Levels.SetActive(true);
        mainmenu.SetActive(false);
        //SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
