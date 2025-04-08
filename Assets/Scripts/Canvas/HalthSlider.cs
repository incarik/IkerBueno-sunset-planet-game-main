using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalthSlider : MonoBehaviour
{
    private Slider _healthBar;
    private Text _livesText;

    void OnEnable()
    {
        PlayerHealth.OnPlayerDamage += UpdateHealthBar;
        PlayerHealth.OnSetLife += SetHealthBar;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDamage -= UpdateHealthBar;
        PlayerHealth.OnSetLife -= SetHealthBar;
    }

    void Awake()
    {
        _healthBar = GetComponentInChildren<Slider>();
        _livesText = GetComponentInChildren<Text>();
    }

    void SetHealthBar(int health, int lives)
    {
        _livesText.text = lives.ToString();
        _healthBar.maxValue = health;
        _healthBar.value = health;
    }
    
    void UpdateHealthBar(int damage)
    {
        if(_healthBar.value > 0)
        {
            _healthBar.value -= damage;
        }
    }
}
