using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : Health
{
    public static event Action <int> OnPlayerDamage;
    public static event Action OnPlayerDeath;
    public static event Action OnGameOver;
    public static event Action<int, int> OnSetLife;

    [SerializeField] private int _maxLives = 3;
    [SerializeField] private int _currentLives;

    public override void Awake()
    {
        base.Awake();
        _currentLives = _maxLives;
    }

    void Start()
    {
        OnSetLife?.Invoke(_maxHealth, _maxLives);
    }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);

        OnPlayerDamage?.Invoke(damageAmount);

        if(_currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        _currentLives--;

        if(_currentLives <= 0)
        {
            Debug.Log("Game Over");
            OnSetLife?.Invoke(0, 0);
            OnGameOver?.Invoke();

            return;
        }

        _currentHealth = _maxHealth;

        OnSetLife?.Invoke(_maxHealth, _currentLives);
        OnPlayerDeath?.Invoke();
    }
}
