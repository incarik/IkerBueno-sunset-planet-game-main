using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    public int _maxHealth = 3;
    public int _currentHealth;
    
    public virtual void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public virtual void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
    }
}
