using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackSpawn;
    [SerializeField] private GameObject _attackPrefab;

    [SerializeField] private float _attackDelay = 0.3f;
    private float _attackTimer = 0;
    private bool _canAttack = true;

    void OnEnable()
    {
        PlayerController.OnPlayerAttack += Attack;
    }

    void OnDisable()
    {
        PlayerController.OnPlayerAttack -= Attack;
    }

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
