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

    public void OnNewGameClicked()
    {
        DisableMenuButtons();
        Debug.Log("New Game Clicked");
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void Exit()
    {
        DisableMenuButtons();
        Debug.Log("Continute Game Clicked");
        Application.Quit();
    
    }

    private void DisableMenuButtons()
    {
        newGameButton.interactable = false;
        continuteGameButton.interactable = false;
    }
}
