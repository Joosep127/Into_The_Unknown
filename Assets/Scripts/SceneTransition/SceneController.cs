using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    #region Singleton
    public static SceneController Instance;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion


    // void Start()
    // {
    //     transitionAnim = GetComponent<Animator>();
    // }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public IEnumerator LoadLevel(int index)
    {
        transitionAnim.Play("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(index);
        transitionAnim.Play("Start");
    }
}
