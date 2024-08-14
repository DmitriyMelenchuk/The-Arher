using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private readonly static int NextLevelConst = 1;

    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private PauseScreen _pauseScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private NextLevelScreen _nextLevelScreen;
    [SerializeField] private SettingMenuScreen _settingMenuScreen;
    [SerializeField] private MoneyWallet _moneyCounter;
    [SerializeField] private Player _player;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _pauseScreen.RestartButtonClick += OnRestartButtonClick;
        _pauseScreen.PlayButtonClick += OnExitButtonClick;
        _pauseScreen.ExitButtonClick += OnExitMainMenuButtonClick;
        _pauseScreen.SettingButtonClick += OnSettingButtonClick;
        _gameScreen.PauseButtonClick += OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick += OnExitMainMenuButtonClick;
        _nextLevelScreen.MainMenuButtonClick += OnExitMainMenuButtonClick;
        _nextLevelScreen.NextLevelButtonClick += OnNextlevelButtonClick;
        _settingMenuScreen.ExitButtonClick += OnSettingClose;
        _enemyCounter.EnemiesAreOver += OnEnemiesAreOver;
        
    }

    private void Start()
    {
        _pauseScreen.Close();
        _gameOverScreen.Close();
        _nextLevelScreen.Close();
        _settingMenuScreen.Close();
        _player._damageable.Died += OnDied;
    }

    private void OnDisable()
    {
        _pauseScreen.RestartButtonClick -= OnRestartButtonClick;
        _pauseScreen.PlayButtonClick -= OnExitButtonClick;
        _pauseScreen.ExitButtonClick -= OnExitMainMenuButtonClick;
        _pauseScreen.SettingButtonClick -= OnSettingButtonClick;
        _gameScreen.PauseButtonClick -= OnPauseButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _gameOverScreen.MainMenuButtonClick -= OnExitMainMenuButtonClick;
        _nextLevelScreen.MainMenuButtonClick -= OnExitMainMenuButtonClick;
        _nextLevelScreen.NextLevelButtonClick -= OnNextlevelButtonClick;
        _settingMenuScreen.ExitButtonClick -= OnSettingClose;
        _enemyCounter.EnemiesAreOver -= OnEnemiesAreOver;
        _player._damageable.Died -= OnDied;
    }

    private void OnSettingButtonClick()
    {
        _settingMenuScreen.Open();
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

    private void OnSettingClose()
    {
        _settingMenuScreen.Close();
    }

    private void OnExitButtonClick()
    {
        CloseScreen();
    }

    private void OnExitMainMenuButtonClick()
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
