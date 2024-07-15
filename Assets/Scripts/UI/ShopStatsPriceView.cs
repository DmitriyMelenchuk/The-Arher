using TMPro;
using UnityEngine;

public class ShopStatsPriceView : MonoBehaviour
{
    [SerializeField] private ShopStatsPrice _shopStatsPrice;
    [SerializeField] private TMP_Text _priceTextHealth;
    [SerializeField] private TMP_Text _priceTextDamage;
    [SerializeField] private TMP_Text _levelAdvanceHealth;
    [SerializeField] private TMP_Text _levelAdvanceDamage;

    private void OnEnable()
    {
        _shopStatsPrice.LevelHealthChanged += OnLevelHealthChanged;
        _shopStatsPrice.LevelDamageChanged += OnLevelDamageChanged;
        _shopStatsPrice.PriceHealthChanged += OnPriceHealthChanged;
        _shopStatsPrice.PriceDamageChanged += OnPriceDamageChanged;
    }

    private void OnDisable()
    {
        _shopStatsPrice.LevelHealthChanged -= OnLevelHealthChanged;
        _shopStatsPrice.LevelDamageChanged -= OnLevelDamageChanged;
        _shopStatsPrice.PriceHealthChanged -= OnPriceHealthChanged;
        _shopStatsPrice.PriceDamageChanged -= OnPriceDamageChanged;
    }

    private void OnPriceDamageChanged(int value)
    {
        _priceTextDamage.text = value.ToString();
    }

    private void OnPriceHealthChanged(int value)
    {
        _priceTextHealth.text = value.ToString();
    }

    private void OnLevelDamageChanged(string text)
    {
        _levelAdvanceDamage.text = text;
    }

    private void OnLevelHealthChanged(string text)
    {
        _levelAdvanceHealth.text = text;
    }
}
