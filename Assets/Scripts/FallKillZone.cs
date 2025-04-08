using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallKillZone : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _respawnPosition;
    private Transform _player;

    void Awake()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    public void Interact()
    {
        _player.position = _respawnPosition.position;

        IDamageable damageable = _player.GetComponent<IDamageable>();
        damageable?.TakeDamage(1);
    }
}
