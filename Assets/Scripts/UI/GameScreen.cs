using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Screen
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _healthPotionButton;

    public event Action PauseButtonClick;
    public event Action HealthPotionButtonClick;

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
    }

    protected override void Disable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
        _healthPotionButton.onClick.RemoveListener(OnHealthPotionButtonClick);
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
