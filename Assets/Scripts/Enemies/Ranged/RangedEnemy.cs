using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    private RangedEnemyAttack _enemyAttack;
    private MortarEnemyAttack _mortarAttack;

    public override void Awake()
    {
        base.Awake();

        _enemyAttack = GetComponent<RangedEnemyAttack>();
        _mortarAttack = GetComponent<MortarEnemyAttack>();
    }

    void Update()
    {
        if(GameManager.instance.currentGameState != GameManager.GameState.Playing)
        {
            return;
        }
        
        if(PlayerInRange(attackRange))
        {
            AimToPlayer();

            if(_enemyAttack != null)
            {
                _enemyAttack.Attack();
                return;
            }

            if(_mortarAttack != null)
            {
                _mortarAttack.Attack();
                return;
            }            
        }
    }
}
