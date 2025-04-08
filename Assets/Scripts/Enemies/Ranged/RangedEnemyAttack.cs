using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAttack : EnemyAttack
{
    [SerializeField] private GameObject _attackPrefab;
    
    public void Attack()
    {
        if(!_canAttack)
        {
            return;
        }
        
        Instantiate(_attackPrefab, _attackSpawn.position, _attackSpawn.rotation);

        _attackTimer = 0;
        _canAttack = false;
    }
}
