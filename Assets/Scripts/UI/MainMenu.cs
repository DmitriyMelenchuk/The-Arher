using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private SelectLevelScreen _selectLevelScreen;
    [SerializeField] private ShopScreen _shopScreen;

    private void Start()
    {
        _mainMenuScreen.Open();
        _selectLevelScreen.Close();
        _shopScreen.Close();
    }

    private void OnEnable()
    {  
        _mainMenuScreen.PlayButtonClick += OnPlayButtonClick;
        _mainMenuScreen.ShopButtonClick += OnShopButtonClick;
        _selectLevelScreen.CloseButtonClick += OnCloseButtonClick;
        _shopScreen.CloseButtonClick += OnCloseButtonClick;
    }

    private void OnDisable()
    {
        _mainMenuScreen.PlayButtonClick -= OnPlayButtonClick;
        _mainMenuScreen.ShopButtonClick -= OnShopButtonClick;
        _selectLevelScreen.CloseButtonClick -= OnCloseButtonClick;
        _shopScreen.CloseButtonClick -= OnCloseButtonClick;
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
