using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : Screen
{
    [SerializeField] private Button _closeScreen;
    [SerializeField] private Button _healthPotionButton;
    [SerializeField] private Button _damagePotionButton;
    [SerializeField] private Button _damageStatsButton;
    [SerializeField] private Button _healthStatsButton;

    public event Action CloseButtonClick;
    public event Action HealthPotionButtonClick;
    public event Action DamagePotionButtonClick;
    public event Action DamageStatsButtonClick;
    public event Action HealthStatsButtonClick;

    protected override void Enable()
    {
        _closeScreen.onClick.AddListener(OnCloseButtonClick);
        _healthPotionButton.onClick.AddListener(OnHealthPotionButtonClick);
        _damagePotionButton.onClick.AddListener(OnDamagePotionButtonClick);
        _damageStatsButton.onClick.AddListener(OnDamageStatsButtonClick);
        _healthStatsButton.onClick.AddListener(OnHealthStatsButtonClick);
    }

    protected override void Disable()
    {
        _closeScreen.onClick.RemoveListener(OnCloseButtonClick);
        _healthPotionButton.onClick.RemoveListener(OnHealthPotionButtonClick);
        _damagePotionButton.onClick.RemoveListener(OnDamagePotionButtonClick);
        _damageStatsButton.onClick.RemoveListener(OnDamageStatsButtonClick);
        _healthStatsButton.onClick.RemoveListener(OnHealthStatsButtonClick);
    }
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _closeScreen.interactable = false;
        _healthPotionButton.interactable = false;
        _damagePotionButton.interactable = false;
        _damageStatsButton.interactable = false;
        _healthStatsButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _closeScreen.interactable = true;
        _healthPotionButton.interactable = true;
        _damagePotionButton.interactable = true;
        _damageStatsButton.interactable = true;
        _healthStatsButton.interactable = true;
        gameObject.SetActive(true);
    }

    private void OnHealthStatsButtonClick()
    {
        HealthStatsButtonClick?.Invoke();
    }

    private void OnDamageStatsButtonClick()
    {
        DamageStatsButtonClick?.Invoke();
    }

    private void OnDamagePotionButtonClick()
    {
        DamagePotionButtonClick?.Invoke();
    }

    private void OnHealthPotionButtonClick()
    {
        HealthPotionButtonClick?.Invoke();
    }

    private void OnCloseButtonClick()
    {
        CloseButtonClick?.Invoke();
    }
}
