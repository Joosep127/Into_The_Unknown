using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    #region Singleton
    public static Health Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();

    }
    private void Update()
    {
        // Debug.Log("Slider value"+ slider.value);
    }

    public void Damage(float damage)
    {
        slider.value -= damage / 100;

        if (slider.value <= 0)
        {
            Debug.Log("dead");
            GameOverController.Instance.SetActive(true);
        }
    }
}
