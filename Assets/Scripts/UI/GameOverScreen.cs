using System;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : Screen
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    public event Action RestartButtonClick;
    public event Action MainMenuButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _restartButton.interactable = false;
        _mainMenuButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _restartButton.interactable = true;
        _mainMenuButton.interactable = true;
        gameObject.SetActive(true);
    }
   
    protected override void Enable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _mainMenuButton.onClick.AddListener(OnMainMenyButtonClick);
    }

    protected override void Disable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _mainMenuButton.onClick.RemoveListener(OnMainMenyButtonClick);
    }

    private void OnMainMenyButtonClick()
    {
        MainMenuButtonClick?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
