using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public LayerMask _playerLayer;
    public Transform _attackSpawn;
    public float _attackRadius = 0.5f;
    [SerializeField] private float _attackDelay = 1f;
    public float _attackTimer = 0;
    public bool _canAttack = true;

    void Update()
    {
        if(!_canAttack)
        {
            AttackTime();
        }
    }

    void AttackTime()
    {
        _attackTimer += Time.deltaTime;

        if(_attackTimer >= _attackDelay)
        {
            _canAttack = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(_attackSpawn.position, _attackRadius);
    }
}
