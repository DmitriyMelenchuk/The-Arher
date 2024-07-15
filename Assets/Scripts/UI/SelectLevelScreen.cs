using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelScreen : Screen
{
    [SerializeField] private Button _closeScreenButton;

    public event Action CloseButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _closeScreenButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _closeScreenButton.interactable = true;
        gameObject.SetActive(true);
    }

 
    protected override void Enable()
    {
        _closeScreenButton.onClick.AddListener(OnCloseScreenButton);
    }

    protected override void Disable()
    {
        _closeScreenButton.onClick.RemoveListener(OnCloseScreenButton);
    }

    private void OnCloseScreenButton()
    {
        CloseButtonClick?.Invoke();
    }
}
