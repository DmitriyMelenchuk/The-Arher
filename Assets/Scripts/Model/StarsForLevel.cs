using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsForLevel : MonoBehaviour
{
    private static string KeyLevel = "";

    private const string Level = "Level";
    private const int OneStar = 1;
    private const int TwoStar = 2;
    private const int ThreeStar = 3;

    private int _currentCountStars;

    [SerializeField] private int _timeForTwoStar;
    [SerializeField] private int _timeForThreeStar;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyCounter _enemyCounter;

    public event Action<int> ChangedCountStars;
    public EnemyCounter EnemyCounter => _enemyCounter;
    public int TimeForTwoStar => _timeForTwoStar;
    public int TimeForThreeStar => _timeForThreeStar;

    private void OnEnable()
    {
        _enemyCounter.EnemiesAreOver += OnLevelComplete;      
    }

    private void Start()
    {
        KeyLevel = Level + SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesAreOver -= OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        _currentCountStars = OneStar;
        
        if (TryGetKeyStars(OneStar))
            SetStars(OneStar);
            
        
        if (_timer.RunnigTime <= _timeForTwoStar)
        {
            _currentCountStars = TwoStar;

            if (TryGetKeyStars(TwoStar))
                SetStars(TwoStar);
        }
                
        if (_timer.RunnigTime <= _timeForThreeStar)
        {
            _currentCountStars = ThreeStar;

            if (TryGetKeyStars(ThreeStar))
                SetStars(ThreeStar);
        }

        ChangedCountStars?.Invoke(_currentCountStars);
    }

    private bool TryGetKeyStars(int value)
    {
        return PlayerPrefs.GetInt(KeyLevel) < value;
    }

    private void SetStars(int value)
    {
        PlayerPrefs.SetInt(KeyLevel, value);
    }
}
