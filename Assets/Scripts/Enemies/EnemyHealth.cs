using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHealth : Health
{
    public static event Action OnEnemyDeath;

    private EnemyAudio _enemyAudio;
    private EnemyParticles _enemyParticles;

    public override void Awake()
    {
        base.Awake();

        _enemyAudio = GetComponent<EnemyAudio>();
        _enemyParticles = GetComponent<EnemyParticles>();
    }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);

        if(_currentHealth > 0)
        {
            //_enemyAudio.PlaySFX(_enemyAudio.damageSound);
            //_enemyParticles.SpawnParticles();
        }
        else
        {
            if(OnEnemyDeath != null)
            {
                OnEnemyDeath();
            }

            //_enemyAudio.PlaySFX(_enemyAudio.deathSound);
            //_enemyParticles.SpawnParticles();

            Destroy(gameObject);
        }
    }
}
