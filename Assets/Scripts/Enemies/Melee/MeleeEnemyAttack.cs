using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyAttack : EnemyAttack
{
    [SerializeField] private int _attackDamage = 1;

    public void Attack()
    {
        if(!_canAttack)
        {
            return;
        }
        
        Collider2D attackedCollider = Physics2D.OverlapCircle(_attackSpawn.position, _attackRadius, _playerLayer);
        IDamageable damageable = attackedCollider.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.TakeDamage(_attackDamage);
        }

        _attackTimer = 0;
        _canAttack = false;
    }
}
