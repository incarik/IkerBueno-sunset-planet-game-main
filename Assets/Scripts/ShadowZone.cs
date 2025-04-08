using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowZone : MonoBehaviour
{
    private IDamageable damageable;

    [SerializeField] private float _zoneSpeed = 2;

    [SerializeField] private int _damage;
    [SerializeField] private float _damageDelay = 3f;
    [SerializeField] private float _damageTimer = 0f;
    [SerializeField] private bool _isInShadowZone = false;

    void Awake()
    {
        damageable = GameObject.FindWithTag("Player").GetComponent<IDamageable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.currentGameState != GameManager.GameState.Playing)
        {
            return;
        }
        
        ZoneMovement();

        if(_isInShadowZone)
        {
            DamageTimer();
        }
    }

    void ZoneMovement()
    {
        transform.position += Vector3.right * _zoneSpeed * Time.deltaTime;
    }

    void DamageTimer()
    {
        _damageTimer += Time.deltaTime;

        if(_damageTimer >= _damageDelay)
        {
            _damageTimer = 0;

            if(damageable != null)
            {
                damageable.TakeDamage(_damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _isInShadowZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            _isInShadowZone = false;
            _damageTimer = 0;
        }
    }
}
