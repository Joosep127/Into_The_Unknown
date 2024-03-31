using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{

    public static SceneController Instance;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter new close trigger level player");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter new level player");
            StartCoroutine(SceneController.Instance.LoadLevel(0));
        }
    }
}
