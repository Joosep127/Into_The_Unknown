using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth = 5f;

    private void Start()
    {
       currentHealth = maxHealth
    }
    public void Damage(float damageAmount)
    {
           
    }
}
