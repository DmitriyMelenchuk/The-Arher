using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private MainMenuScreen _mainMenuScreen;
    [SerializeField] private SelectLevelScreen _selectLevelScreen;

    private void Start()
    {
        _mainMenuScreen.Open();
        _selectLevelScreen.Close();
    }

    private void OnEnable()
    {  
        _mainMenuScreen.PlayButtonClick += OnPlayButtonClick;
        _selectLevelScreen.CloseButtonClick += OnCloseButtonClick;
    }

    private void OnDisable()
    {
        _mainMenuScreen.PlayButtonClick -= OnPlayButtonClick;
        _selectLevelScreen.CloseButtonClick -= OnCloseButtonClick;
    }

    private void OnCloseButtonClick()
    {
        _selectLevelScreen.Close();
    }

    private void OnPlayButtonClick()
    {
        _selectLevelScreen.Open();
        Time.timeScale = 1;
    }
}
