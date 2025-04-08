using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform _playerTransform{get; private set;}
    public float detectionDistance = 5;
    public float attackRange = 3;

    public virtual void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }
    
    public bool PlayerInRange(float range)
    {
        return Vector3.Distance(_playerTransform.position, transform.position) < range;
    }

    public void AimToPlayer()
    {
        if(_playerTransform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(_playerTransform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    /*public float PlayerDirection()
    {
        Vector3 direction = (_playerTransform.position - transform.position).normalized;
        float playerDirection = direction.x;

        if(playerDirection > 0)
        {
            playerDirection = 1;
        }
        else if(playerDirection < 0)
        {
            playerDirection = -1;
        }

        return playerDirection;
    }*/

    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
