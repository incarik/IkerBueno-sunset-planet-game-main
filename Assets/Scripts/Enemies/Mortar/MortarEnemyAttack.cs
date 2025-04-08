using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarEnemyAttack : EnemyAttack
{
    [SerializeField] private GameObject _attackPrefab;
    [SerializeField] private int _numberOfAttacks = 3;
    [SerializeField] private float[] _attackAngles;

    public void Attack()
    {
        if(!_canAttack)
        {
            return;
        }

        _attackTimer = 0;
        _canAttack = false;

        StartCoroutine(MortarAttack());
    }

    IEnumerator MortarAttack()
    {
        for (int i = 0; i < _numberOfAttacks; i++)
        {
            Instantiate(_attackPrefab, _attackSpawn.position, Quaternion.Euler(_attackSpawn.eulerAngles.x, _attackSpawn.eulerAngles.y, _attackSpawn.eulerAngles.z + _attackAngles[i]));

            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
