using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enter new close trigger level player");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter new level player");
            SceneController.Instance.NextLevel();
        }
    }
}
