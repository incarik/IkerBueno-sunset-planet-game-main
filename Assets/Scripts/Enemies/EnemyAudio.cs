using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAudio : MonoBehaviour
{
    private AudioSource _enemyAudioSource;

    public AudioClip attackSound;
    public AudioClip damageSound;
    public AudioClip deathSound;

    void Awake()
    {
        _enemyAudioSource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip clip)
    {
        Debug.Log("sonido de SFX");

        /*if(clip != null)
        {
            _playerAudioSource.PlayOneShot(clip);
        }*/
    }
}
