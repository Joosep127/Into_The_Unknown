using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
        public GameObject MainMenu;
        public GameObject levels;
        [SerializeField] Animator transitionAnim;
        public void Back()
        {
                MainMenu.SetActive(true);
                levels.SetActive(false);
        }

        public void One()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(2 - 1));
        }

        public void Two()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(3 - 1));
        }

        public void Three()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(4 - 1));
        }

        public void Four()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(5 - 1));
        }

        public void Five()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(6 - 1));
        }

        public void Six()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(7 - 1));
        }

        public void Seven()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(8 - 1));
        }

        public void Eight()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(9 - 1));
        }

        public void Nine()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(10 - 1));
        }

        public void Ten()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(11 - 1));
        }

        public void Eleven()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(12 - 1));
        }

        public void Twelve()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(13 - 1));
        }

        public void Thirteen()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(14 - 1));
        }

        public void Fourteen()
        {
                StartCoroutine(SceneController.Instance.LoadLevel(15 - 1));

        }
}
