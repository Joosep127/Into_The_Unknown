@ -0,0 + 1,19 @@
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainMenu : MonoBehaviour
{

    public static SceneController Instance;
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SceneController.Instance.LoadLevel(0));
        }
    }
}