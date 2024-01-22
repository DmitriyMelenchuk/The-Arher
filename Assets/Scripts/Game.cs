using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;

    private void Start()
    {
        _pauseScreen.Close();
    }

    private void OnEnable()
    {
        _pauseScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.PlayButtonClick += OnPlayButtonClick;
        _gameScreen.PauseButtonClick += OnPauseButtonClick;
    }

    private void OnDisable()
    {
        _pauseScreen.RestartButtonClick -= OnRestartButtonClick;
        _pauseScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameScreen.PauseButtonClick -= OnPauseButtonClick;
    }

    private void OnPauseButtonClick()
    {
        _pauseScreen.Open();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _player.Reset();
        _enemy.Reset();
    }

    private void OnPlayButtonClick()
    {
        _pauseScreen.Close();
        Time.timeScale = 1;
    }
}
