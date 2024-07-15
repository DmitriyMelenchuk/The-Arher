using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Screen
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _healthPotionButton;
    [SerializeField] private Button _damagePotionButton;

    public event Action PauseButtonClick;
    public event Action HealthPotionButtonClick;
    public event Action DamagePotionButtonClick;

    public override void Close()
    {
    }

    public override void Open()
    {
    }

    protected override void Enable()
    {
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _pauseButton.interactable = true;
        _healthPotionButton.onClick.AddListener(OnHealthPotionButtonClick);
        _damagePotionButton.onClick.AddListener(OnDamagePotionButtonClick);
    }

    protected override void Disable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _healthPotionButton.onClick.RemoveListener(OnHealthPotionButtonClick);
        _damagePotionButton.onClick.RemoveListener(OnDamagePotionButtonClick);
    }

    private void OnDamagePotionButtonClick()
    {
        DamagePotionButtonClick?.Invoke();
    }

    private void OnPauseButtonClick()
    {
        PauseButtonClick?.Invoke();
    }

    private void OnHealthPotionButtonClick()
    {
        HealthPotionButtonClick?.Invoke();
    }
}
