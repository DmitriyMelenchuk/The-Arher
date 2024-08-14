using System;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private SelectLevelScreen _selectLevelScreen;
    [SerializeField] private ShopScreen _shopScreen;
    [SerializeField] private SettingMenuScreen _settingMenuScreen;

    private void Start()
    {
        _mainMenuScreen.Open();
        _selectLevelScreen.Close();
        _shopScreen.Close();
        _settingMenuScreen.Close();
    }

    private void OnEnable()
    {  
        _mainMenuScreen.PlayButtonClick += OnPlayButtonClick;
        _mainMenuScreen.ShopButtonClick += OnShopButtonClick;
        _mainMenuScreen.SettingsButtonClick += OnSettingButtonClick;
        _selectLevelScreen.CloseButtonClick += OnCloseButtonClick;
        _shopScreen.CloseButtonClick += OnCloseButtonClick;
        _settingMenuScreen.ExitButtonClick += OnSettingCloseButtonClick;
    }

    private void OnDisable()
    {
        _mainMenuScreen.PlayButtonClick -= OnPlayButtonClick;
        _mainMenuScreen.ShopButtonClick -= OnShopButtonClick;
        _mainMenuScreen.SettingsButtonClick -= OnSettingButtonClick;
        _selectLevelScreen.CloseButtonClick -= OnCloseButtonClick;
        _shopScreen.CloseButtonClick -= OnCloseButtonClick;
        _settingMenuScreen.ExitButtonClick -= OnSettingCloseButtonClick;
    }

    private void OnSettingButtonClick()
    {
        _settingMenuScreen.Open();
    }

    private void OnSettingCloseButtonClick()
    {
        _settingMenuScreen.Close();
    }

    private void OnShopButtonClick()
    {
        _shopScreen.Open();
    }

    private void OnCloseButtonClick()
    {
        _selectLevelScreen.Close();
        _shopScreen.Close();
    }

    private void OnPlayButtonClick()
    {
        _selectLevelScreen.Open();
    }
}
