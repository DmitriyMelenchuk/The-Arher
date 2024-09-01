using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class HealthPotion : MonoBehaviour, IPotion
{
    private const string _keyPotionCount = "healthPotionCount";
    private const int _count = 1;

    [SerializeField] private Player _player;
    [SerializeField] private float _percentAddHealth;

    public event Action<int> ValueChanged;

    private void Start()
    {
        ValueChanged?.Invoke(PlayerPrefs.GetInt(_keyPotionCount));
    }

    public void Use()
    {
        if (_player._damageable is PlayerHealth playerHealth)
        {
            if (PlayerPrefs.GetInt(_keyPotionCount) > 0)
            {
                playerHealth.HealHealth(_percentAddHealth);
                PlayerPrefs.SetInt(_keyPotionCount, PlayerPrefs.GetInt(_keyPotionCount) - _count);
                PlayerPrefs.Save();
                ValueChanged?.Invoke(PlayerPrefs.GetInt(_keyPotionCount));
            }
        }
    }
}
