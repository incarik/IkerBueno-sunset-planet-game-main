using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MeleeEnemyAttack))]
public class MeleeEnemy : Enemy
{
    public enum EnemyState
    {
        Patrol,
        Chase,
        Attack
    }

    [SerializeField] private EnemyState _currentState;

    private MeleeEnemyAttack _enemyAttack;

    [SerializeField] private float _movementSpeed = 5;

    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private int _patrolIndex = 0;

    public override void Awake()
    {
        base.Awake();

        _enemyAttack = GetComponent<MeleeEnemyAttack>();
    }

    void Update()
    {
        if(GameManager.instance.currentGameState != GameManager.GameState.Playing)
        {
            return;
        }
        
        switch (_currentState)
        {
            case EnemyState.Patrol:
                Patrolling();
            break;
            case EnemyState.Chase:
                Chasing();
            break;
            case EnemyState.Attack:
                Attacking();
            break;
        }
    }

    void Patrolling()
    {
        if(base.PlayerInRange(base.detectionDistance))
        {
            _currentState = EnemyState.Chase;
        }

        if(Vector3.Distance(transform.position, _patrolPoints[_patrolIndex].position) <0.5f)
        {
            if(_patrolIndex < _patrolPoints.Length - 1)
            {
                _patrolIndex++;
                Debug.Log("mira izquierda???");
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                _patrolIndex = 0;
                Debug.Log("mira derecha???");
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }   

        transform.position = Vector2.MoveTowards(transform.position, _patrolPoints[_patrolIndex].position, _movementSpeed * Time.deltaTime);
    }

    void Chasing()
    {
        if(base.PlayerInRange(base.attackRange))
        {
            _currentState = EnemyState.Attack;
        }
        else if(!base.PlayerInRange(base.detectionDistance))
        {
            if(_patrolPoints[_patrolIndex].position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if(_patrolPoints[_patrolIndex].position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            _currentState = EnemyState.Patrol;

            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(base._playerTransform.position.x, transform.position.y), _movementSpeed * Time.deltaTime);

        AimToPlayer();
    }

    void Attacking()
    {
        if(!base.PlayerInRange(base.attackRange))
        {
            _currentState = EnemyState.Chase;
        }

        _enemyAttack.Attack();
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();

        foreach (Transform patrolPoint in _patrolPoints)
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawWireSphere(patrolPoint.position, 0.5f);
        }
    }
}
