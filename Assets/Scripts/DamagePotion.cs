using System;
using UnityEngine;

public class DamagePotion : MonoBehaviour, IPotion
{
    private const string _keyPotionCount = "damagePotionCount";
    private const int _valuePotion = 1;

    [SerializeField] private Player _player;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _percentAdvanceDamage;

    public event Action<int> ValueChanged;

    private void Start()
    {
        ValueChanged?.Invoke(PlayerPrefs.GetInt(_keyPotionCount));
    }
    public void Use()
    {
        if (PlayerPrefs.GetInt(_keyPotionCount) > 0) 
        {
            StartCoroutine(_player.PlayerDamage.AddDamageForTime(_durationTime, _percentAdvanceDamage));
            PlayerPrefs.SetInt(_keyPotionCount, PlayerPrefs.GetInt(_keyPotionCount) - _valuePotion);
            ValueChanged?.Invoke(PlayerPrefs.GetInt(_keyPotionCount));
        }
    }
}
