using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : Screen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _shopButton;
    [SerializeField] private Button _settingsButton;

    public event Action PlayButtonClick;
    public event Action ShopButtonClick;
    public event Action SettingsButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _playButton.interactable = false;
        _shopButton.interactable = false;
        _settingsButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _playButton.interactable = true;
        _shopButton.interactable = true;
        _settingsButton.interactable = true;
        gameObject.SetActive(true);
    }

    protected override void Enable()
    {
        _playButton.onClick.AddListener(OnPlayButtonClick);
        _shopButton.onClick.AddListener(OnShopButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    protected override void Disable()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClick);
        _shopButton.onClick.RemoveListener(OnShopButtonClick);
        _settingsButton.onClick.RemoveListener(OnSettingsButtonClick);
    }

    private void OnPlayButtonClick()
    {
        PlayButtonClick?.Invoke();
    }

    private void OnShopButtonClick()
    {
        ShopButtonClick?.Invoke();
    }

    private void OnSettingsButtonClick()
    {
        SettingsButtonClick?.Invoke();
    }
}
