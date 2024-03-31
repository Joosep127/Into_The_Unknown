using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Works, don't touch it
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth = 5f;

    private float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        Debug.Log("Damage");
        if (currentHealth <= 0)
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }
}
