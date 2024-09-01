using System;
using UnityEngine;
using PlayerPrefs = Agava.YandexGames.Utility.PlayerPrefs;

public class ShopStatsPrice : MonoBehaviour
{
    private const string _keyHealth = "playerHealth";
    private const string _keyDamage = "playerDamage";
    private const string _keyPriceHealth = "priceHealth";
    private const string _keyPriceDamage = "priceDamage";
    private const string _keyLevelAdvanceHealth = "levelHealth";
    private const string _keyLevelAdvanceDamage = "levelDamage";
    private const int _playerValueStats = 1;
    private const int _maxLevelAdvance = 10;
    private const int _valueAdvance = 5;
    private const int _multiplierPrice = _valueAdvance * 5;

    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private MoneyWallet _moneyWallet;
    [SerializeField] private AudioSource _buySound;

    public int Damage => PlayerPrefs.GetInt(_keyDamage);
    public int Health => PlayerPrefs.GetInt(_keyHealth);
    public int CurrentLevelAdvanceHealth => PlayerPrefs.GetInt(_keyLevelAdvanceHealth);
    public int CurrentLevelAdvanceDamage => PlayerPrefs.GetInt(_keyLevelAdvanceDamage);
    public int CurrentPriceHealth => PlayerPrefs.GetInt(_keyPriceHealth);
    public int CurrentPriceDamage => PlayerPrefs.GetInt(_keyPriceDamage);

    public event Action<string> LevelHealthChanged;
    public event Action<string> LevelDamageChanged;
    public event Action<int> PriceHealthChanged;
    public event Action<int> PriceDamageChanged;

    private void OnEnable()
    {
        //PlayerPrefs.DeleteKey(_keyPriceHealth);
        //PlayerPrefs.DeleteKey(_keyPriceDamage);
        //PlayerPrefs.DeleteKey(_keyLevelAdvanceHealth);
        //PlayerPrefs.DeleteKey(_keyLevelAdvanceDamage);

        _shopScreen.HealthStatsButtonClick += OnHealthStatsButtonClick;
        _shopScreen.DamageStatsButtonClick += OnDamageStatsButtonClick;      
    }

    private void Start()
    {
        LevelHealthChanged?.Invoke(CurrentLevelAdvanceHealth.ToString() + "/10");
        LevelDamageChanged?.Invoke(CurrentLevelAdvanceDamage.ToString() + "/10");

        if (CurrentPriceDamage == 0)
            PlayerPrefs.SetInt(_keyPriceDamage, _valueAdvance);

        if (CurrentPriceHealth == 0)
            PlayerPrefs.SetInt(_keyPriceHealth, _valueAdvance);

        PlayerPrefs.Save();
        PriceDamageChanged?.Invoke(CurrentPriceDamage);
        PriceHealthChanged?.Invoke(CurrentPriceHealth);
    }

    private void OnDisable()
    {
        _shopScreen.HealthStatsButtonClick -= OnHealthStatsButtonClick;
        _shopScreen.DamageStatsButtonClick -= OnDamageStatsButtonClick;
    }

    private void OnHealthStatsButtonClick()
    {
        CalculatePriceStats(CurrentLevelAdvanceHealth, CurrentPriceHealth, _keyPriceHealth, _keyLevelAdvanceHealth);
        SetMaxHealth(_playerValueStats);
        _buySound.Play();
        LevelHealthChanged?.Invoke(CurrentLevelAdvanceHealth.ToString() + "/10");
        PriceHealthChanged?.Invoke(CurrentPriceHealth);
    }

    private void OnDamageStatsButtonClick()
    {
        CalculatePriceStats(CurrentLevelAdvanceDamage, CurrentPriceDamage, _keyPriceDamage, _keyLevelAdvanceDamage);
        SetMaxDamage(_playerValueStats);
        _buySound.Play();
        LevelDamageChanged?.Invoke(CurrentLevelAdvanceDamage.ToString() + "/10");
        PriceDamageChanged?.Invoke(CurrentPriceDamage);
    }

    private void CalculatePriceStats(int currentLevelAdvance, int currentPrice, string keyPrice, string keyLevelAdvance)
    {
        int index = 1;

        if (currentLevelAdvance < _maxLevelAdvance)
        {
            if (_moneyWallet.TryRemove(currentPrice) == true)
            {
                if (currentLevelAdvance >= _valueAdvance)
                    PlayerPrefs.SetInt(keyPrice, currentPrice + _multiplierPrice);

                else
                    PlayerPrefs.SetInt(keyPrice, currentPrice + _valueAdvance);

                PlayerPrefs.SetInt(keyLevelAdvance, currentLevelAdvance + index);
                PlayerPrefs.Save();
            }
        }
    }

    public void SetMaxDamage(int value)
    {
        if (value > 0)
        {
            PlayerPrefs.SetInt(_keyDamage, Damage + value);
            PlayerPrefs.Save();
        }
            
    }

    public void SetMaxHealth(int value)
    {
        if (value > 0)
        {
            PlayerPrefs.SetInt(_keyHealth, Health + value);
            PlayerPrefs.Save();
        }
    }
}
