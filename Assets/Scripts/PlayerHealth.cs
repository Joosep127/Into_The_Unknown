using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    // #region Singleton
    // public static PlayerHealth Instance;
    // private void Awake()
    // {
    //     Instance = this;
    // }
    // #endregion

    public float health;
    public float maxHealth;

    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;

    }

    // Update is called once per frame
    void Update()
    {
        // healthBar.fillAmount = maxHealth - Mathf.Clamp(health/maxHealth,0,1);
    }

    
    public void Damage(float damage) 
    {
        Debug.Log("damaged");
        health -= damage;
        // healthBar.fillAmount = health;
    }
}
