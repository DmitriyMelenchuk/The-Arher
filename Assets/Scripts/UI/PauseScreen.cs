using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : Screen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _settingButton;
    [SerializeField] private Button _exitButton;

    public event Action PlayButtonClick;
    public event Action RestartButtonClick;
    public event Action SettingButtonClick;
    public event Action ExitButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _restartButton.interactable = false;
        _exitButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _playButton.interactable = true;
        _restartButton.interactable = true;
        _exitButton.interactable = true;
        gameObject.SetActive(true);
    }

    protected override void Enable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _settingButton.onClick.AddListener(OnSettingButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected override void Disable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _settingButton.onClick.RemoveListener(OnSettingButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OnSettingButtonClick()
    {
        SettingButtonClick?.Invoke();
    }

    private void OnPlayButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }

    private void OnExitButtonClick()
    {
        ExitButtonClick?.Invoke();
    } 
}
