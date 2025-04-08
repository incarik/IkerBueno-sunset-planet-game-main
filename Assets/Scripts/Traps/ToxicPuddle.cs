using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicPuddle : MonoBehaviour
{
    private IDamageable damageable;

    [SerializeField] private int _puddleDamage = 1;
    [SerializeField] private float _puddleDamageDelay = 2;
    private float _puddleDelayTimer = 0;
    private bool _playerInPuddle = false;

    [Tooltip("If this is true the puddles gets deactivated automaticaly")]
    [SerializeField] private bool _hasLifeTime = true;
    [SerializeField] private float _puddleLifeTime = 5;
    private float _lifeTimer = 0;

    void Awake()
    {
        damageable = GameObject.FindWithTag("Player").GetComponent<IDamageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _puddleDelayTimer = _puddleDamageDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerInPuddle)
        {
            DamageOverTime();
        }

        if(!_hasLifeTime)
        {
            return;
        }

        if(_lifeTimer < _puddleLifeTime)
        {
            _lifeTimer += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            _lifeTimer = 0;
        }
    }

    void DamageOverTime()
    {
        if(_puddleDelayTimer < _puddleDamageDelay)
        {
            _puddleDelayTimer += Time.deltaTime;
        }
        else
        {
            _puddleDelayTimer = 0;
            damageable.TakeDamage(_puddleDamage);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _playerInPuddle = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _playerInPuddle = false;
        }
    }
}
