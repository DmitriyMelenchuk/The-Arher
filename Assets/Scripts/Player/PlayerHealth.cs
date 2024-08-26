using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class PlayerHealth : IDamageable
{
    private const string _keyHealth = "playerHealth";
    private int _currentHealth;

    public int Health => PlayerPrefs.GetInt(_keyHealth);

    public event Action Died;
    public event Action<int> ChangedHealth;
    public event Action<int> TakedDamage;

    public PlayerHealth(int value)
    {
        if (Health < value)
            PlayerPrefs.SetInt(_keyHealth, value);
        
        _currentHealth = Health;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        TakedDamage?.Invoke(damage);
        ChangedHealth?.Invoke(_currentHealth);

        if (_currentHealth < 0)
            _currentHealth = 0;

        if (_currentHealth == 0 )
            Died?.Invoke();
    }

    public void HealHealth(float percentAddHealth)
    {
        int value = (int)(Health * percentAddHealth);

        if (_currentHealth + value <= Health)
            _currentHealth += value;
        else
            _currentHealth = Health;

        ChangedHealth?.Invoke(_currentHealth);
    }
}
