using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _playerAudioSource;

    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _damageSound;
    [SerializeField] private AudioClip _deathSound;

    void OnEnable()
    {
        //PlayerHealth.OnPlayerDamage += (int i) => PlaySFX(_damageSound);
        PlayerHealth.OnPlayerDamage += (int i) => PlaySFX();
        PlayerHealth.OnPlayerDeath += PlayDeathSound;
        PlayerController.OnPlayerJump += PlaySFX;
        PlayerController.OnPlayerAttack += PlaySFX;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDamage -= (int i) => PlaySFX();
        PlayerHealth.OnPlayerDeath -= PlayDeathSound;
        PlayerController.OnPlayerJump -= PlaySFX;
        PlayerController.OnPlayerAttack -= PlaySFX;
    }

    void Awake()
    {
        _playerAudioSource = GetComponent<AudioSource>();
    }

    void PlayDeathSound()
    {
        Debug.Log("sonido de muerte");
    }

    void PlaySFX()
    {
        Debug.Log("sonido de SFX");

        /*if(clip != null)
        {
            _playerAudioSource.PlayOneShot(clip);
        }*/
    }
}
