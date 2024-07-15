using System;
using UnityEngine;

public class ShopStatsPrice : MonoBehaviour
{
    private const string PriceKeyHealth = "priceHealth";
    private const string PriceKeyDamage = "priceDamage";
    private const string LevelAdvanceHealthKey = "levelHealth";
    private const string LevelAdvanceDamageKey = "levelDamage";
    private const int MaxLevelAdvance = 10;
    private const int ValueAdvance = 5;
    private const int StartPrice = 5;
    private const int MultiplierPrice = ValueAdvance * 5;

    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private MoneyCounter _moneyCounter;

    public int CurrentLevelAdvanceHealth => PlayerPrefs.GetInt(LevelAdvanceHealthKey);
    public int CurrentLevelAdvanceDamage => PlayerPrefs.GetInt(LevelAdvanceDamageKey);
    public int CurrentPriceHealth => PlayerPrefs.GetInt(PriceKeyHealth);
    public int CurrentPriceDamage => PlayerPrefs.GetInt(PriceKeyDamage);

    public event Action<string> LevelHealthChanged;
    public event Action<string> LevelDamageChanged;
    public event Action<int> PriceHealthChanged;
    public event Action<int> PriceDamageChanged;


    private void OnEnable()
    {
        PlayerPrefs.DeleteKey(PriceKeyHealth);
        PlayerPrefs.DeleteKey(PriceKeyDamage);
        PlayerPrefs.DeleteKey(LevelAdvanceHealthKey);
        PlayerPrefs.DeleteKey(LevelAdvanceDamageKey);

        _shopScreen.HealthStatsButtonClick += OnHealthStatsButtonClick;
        _shopScreen.DamageStatsButtonClick += OnDamageStatsButtonClick;
       
    }

    private void Start()
    {
        LevelHealthChanged?.Invoke(CurrentLevelAdvanceHealth.ToString() + "/10");
        LevelDamageChanged?.Invoke(CurrentLevelAdvanceDamage.ToString() + "/10");
    }

    private void OnDisable()
    {
        _shopScreen.HealthStatsButtonClick -= OnHealthStatsButtonClick;
        _shopScreen.DamageStatsButtonClick -= OnDamageStatsButtonClick;
    }

    private void OnHealthStatsButtonClick()
    {
        int index = 1;

        if (CurrentLevelAdvanceHealth < MaxLevelAdvance)
        {
            if (_moneyCounter.Money >= CurrentPriceHealth)
            {
                if (CurrentLevelAdvanceHealth == 0)
                    PlayerPrefs.SetInt(PriceKeyHealth, CurrentPriceHealth + ValueAdvance);

                _moneyCounter.Remove(CurrentPriceHealth);
                if (CurrentLevelAdvanceHealth >= ValueAdvance)
                    PlayerPrefs.SetInt(PriceKeyHealth, CurrentPriceHealth + MultiplierPrice);

                else
                    PlayerPrefs.SetInt(PriceKeyHealth, CurrentPriceHealth + ValueAdvance);

                
                PlayerPrefs.SetInt(LevelAdvanceHealthKey, CurrentLevelAdvanceHealth + index);
                LevelHealthChanged?.Invoke(CurrentLevelAdvanceHealth.ToString() + "/10");
                PriceHealthChanged?.Invoke(CurrentPriceHealth);
            }  
        }
    }

    private void OnDamageStatsButtonClick()
    {
        int index = 1;

        if (CurrentLevelAdvanceDamage < MaxLevelAdvance)
        {
            if (_moneyCounter.Money >= CurrentLevelAdvanceDamage)
            {
                if (CurrentLevelAdvanceDamage == 0)
                    PlayerPrefs.SetInt(PriceKeyDamage, CurrentPriceDamage + ValueAdvance);

                _moneyCounter.Remove(CurrentPriceDamage);

                if (CurrentLevelAdvanceHealth >= ValueAdvance)
                    PlayerPrefs.SetInt(PriceKeyDamage, CurrentPriceDamage + MultiplierPrice);

                else
                    PlayerPrefs.SetInt(PriceKeyDamage, CurrentPriceDamage + ValueAdvance);

                PlayerPrefs.SetInt(LevelAdvanceDamageKey, CurrentLevelAdvanceDamage + index);
                LevelDamageChanged?.Invoke(CurrentLevelAdvanceDamage.ToString() + "/10");
                PriceDamageChanged?.Invoke(CurrentPriceDamage);
            }
        }
    }
}
