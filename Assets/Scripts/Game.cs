using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private readonly static int NextLevelConst = 1;

    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private NextLevelScreen _nextLevelScreen;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyCounter _enemyCounter;


    private void Start()
    {
        _pauseScreen.Close();
        _gameOverScreen.Close();
        _nextLevelScreen.Close();
    }

    private void OnEnable()
    {
        _pauseScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.PlayButtonClick += OnPlayButtonClick;
        _pauseScreen.ExitButtonClick += OnExitButtonClick;
        _gameScreen.PauseButtonClick += OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick += OnExitButtonClick;
        _nextLevelScreen.MainMenuButtonClick += OnExitButtonClick;
        _nextLevelScreen.NextLevelButtonClick += OnNextlevelButtonClick;
        _enemyCounter.EnemiesAreOver += OnEnemiesAreOver;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _pauseScreen.RestartButtonClick -= OnRestartButtonClick;
        _pauseScreen.PlayButtonClick -= OnPlayButtonClick;
        _pauseScreen.ExitButtonClick -= OnExitButtonClick;
        _gameScreen.PauseButtonClick -= OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick -= OnExitButtonClick;
        _nextLevelScreen.MainMenuButtonClick -= OnExitButtonClick;
        _nextLevelScreen.NextLevelButtonClick -= OnNextlevelButtonClick;
        _enemyCounter.EnemiesAreOver -= OnEnemiesAreOver;
        _player.Died -= OnDied;
    }

    private void OnEnemiesAreOver()
    {
        _nextLevelScreen.Open();
        Time.timeScale = 0;
    }

    private void OnNextlevelButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextLevelConst);
        CloseScreen();
    }

    private void OnDied()
    {
        _gameOverScreen.Open();
        Time.timeScale = 0;
    }

    private void OnPauseButtonClick()
    {
        OpenPauseScreen();
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CloseScreen();
    }

    private void OnPlayButtonClick()
    {
        CloseScreen();
    }

    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    private void CloseScreen()
    {
        _pauseScreen.Close();
        Time.timeScale = 1;
    }

    private void OpenPauseScreen()
    {
        _pauseScreen.Open();
        Time.timeScale = 0;
    }
}
