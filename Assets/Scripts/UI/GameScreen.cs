using System;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Screen
{
    [SerializeField] private Button _pauseButton;

    public event Action PauseButtonClick;

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
    }

    protected override void Disable()
    {
        _pauseButton.onClick.RemoveListener(OnPauseButtonClick);
    }

    private void OnPauseButtonClick()
    {
        PauseButtonClick?.Invoke();
    }
}
