using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticles : MonoBehaviour
{
    void OnEnable()
    {
        PlayerHealth.OnPlayerDamage += (int i) => SpawnParticles();
        PlayerController.OnPlayerJump += SpawnParticles;
        PlayerController.OnPlayerAttack += SpawnParticles;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDamage -= (int i) => SpawnParticles();
        PlayerController.OnPlayerJump -= SpawnParticles;
        PlayerController.OnPlayerAttack -= SpawnParticles;
    }

    void SpawnParticles()
    {
        Debug.Log("spawn particulas");
    }
}
