using System;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelScreen : Screen
{
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Timer _timer;
 
    public event Action NextLevelButtonClick;
    public event Action MainMenuButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _nextLevelButton.interactable = false;
        _mainMenuButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _nextLevelButton.interactable = true;
        _mainMenuButton.interactable = true;
        gameObject.SetActive(true);
    }

    protected override void Enable()
    {
        _nextLevelButton.onClick.AddListener(OnNextLevelScreen);
        _mainMenuButton.onClick.AddListener(OnMainMenuScreen);
    }

    protected override void Disable()
    {
        _nextLevelButton.onClick.RemoveListener(OnNextLevelScreen);
        _mainMenuButton.onClick.RemoveListener(OnMainMenuScreen);
    }

    private void OnNextLevelScreen()
    {
        NextLevelButtonClick?.Invoke();
    }

    private void OnMainMenuScreen()
    {
        MainMenuButtonClick?.Invoke();
    }
}
