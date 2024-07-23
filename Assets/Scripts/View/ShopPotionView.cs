using System;
using TMPro;
using UnityEngine;

public class ShopPotionView : MonoBehaviour
{
    [SerializeField] private ShopPotion _shopPotion;
    [SerializeField] private TMP_Text _healthPotionText;
    [SerializeField] private TMP_Text _damagePotionText;

    private void OnEnable()
    {
        _shopPotion.HealthPotionCountChanged += OnHealthPotionCountChanged;
        _shopPotion.DamagePotionCountChanged += OnDamagePotionCountChanged;
    }

    private void OnDisable()
    {
        _shopPotion.HealthPotionCountChanged -= OnHealthPotionCountChanged;
        _shopPotion.DamagePotionCountChanged -= OnDamagePotionCountChanged;
    }

    private void OnHealthPotionCountChanged(int value)
    {
        _healthPotionText.text = value.ToString();
    }

    private void OnDamagePotionCountChanged(int value)
    {
        _damagePotionText.text = value.ToString();
    }
}
