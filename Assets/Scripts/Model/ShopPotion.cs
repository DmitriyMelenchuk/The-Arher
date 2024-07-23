using System;
using UnityEngine;

public class ShopPotion : MonoBehaviour
{
    private const string _keyHealthPotion = "healthPotionCount";
    private const string _keyDamagePotion = "damagePotionCount";
    private const int _pricePotion = 5;
    private const int _count = 1;

    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private MoneyWallet _moneyWallet;

    public event Action<int> HealthPotionCountChanged;
    public event Action<int> DamagePotionCountChanged;

    private void OnEnable()
    {
        _shopScreen.HealthPotionButtonClick += OnHealthPotionButtonClick;
        _shopScreen.DamagePotionButtonClick += OnDamagePotionButtonClick;
    }

    private void Start()
    {
        HealthPotionCountChanged?.Invoke(PlayerPrefs.GetInt(_keyHealthPotion));
        DamagePotionCountChanged?.Invoke(PlayerPrefs.GetInt(_keyDamagePotion));
    }

    private void OnDisable()
    {
        _shopScreen.HealthPotionButtonClick -= OnHealthPotionButtonClick;
        _shopScreen.DamagePotionButtonClick -= OnDamagePotionButtonClick;
    }
   
    private void OnHealthPotionButtonClick()
    {
        SetValuePotion(_keyHealthPotion, HealthPotionCountChanged);
    }

    private void OnDamagePotionButtonClick()
    {
        SetValuePotion(_keyDamagePotion, DamagePotionCountChanged);
    }

    private void SetValuePotion(string keyPotion, Action<int> action)
    {
        if (_moneyWallet.Money >= _pricePotion)
        {
            PlayerPrefs.SetInt(keyPotion, PlayerPrefs.GetInt(keyPotion) + _count);
            action?.Invoke(PlayerPrefs.GetInt(keyPotion));
        } 
    }
}
