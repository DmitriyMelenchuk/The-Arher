using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void Start()
    {
        _pauseScreen.Close();
        _gameOverScreen.Close();
    }

    private void OnEnable()
    {
        _pauseScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.PlayButtonClick += OnPlayButtonClick;
        _pauseScreen.ExitButtonClick += OnExitButtonClick;
        _gameScreen.PauseButtonClick += OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick += OnExitButtonClick;
    }

    private void OnDisable()
    {
        _pauseScreen.RestartButtonClick -= OnRestartButtonClick;
        _pauseScreen.PlayButtonClick -= OnPlayButtonClick;
        _pauseScreen.ExitButtonClick -= OnExitButtonClick;
        _gameScreen.PauseButtonClick -= OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick -= OnExitButtonClick;
    }

    private void OnPauseButtonClick()
    {
        _pauseScreen.Open();
        Time.timeScale = 0;       
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _pauseScreen.Close();
        Time.timeScale = 1;
    }

    private void OnPlayButtonClick()
    {
        _pauseScreen.Close();
        Time.timeScale = 1;
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
