using System;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsForLevel : MonoBehaviour
{
    private static string _keyStars = "stars";

    private const int _oneStar = 1;
    private const int _twoStar = 2;
    private const int _threeStar = 3;

    [SerializeField] private int _timeForTwoStar;
    [SerializeField] private int _timeForThreeStar;
    [SerializeField] private Timer _timer;
    [SerializeField] private EnemyCounter _enemyCounter;

    private void OnEnable()
    {
        _enemyCounter.EnemiesAreOver += OnLevelComplete;      
    }

    private void Start()
    {
        _keyStars += SceneManager.GetActiveScene().buildIndex.ToString();
    }

    private void OnDisable()
    {
        _enemyCounter.EnemiesAreOver -= OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        if (TryGetKeyStars(_oneStar))
            SetStars(_oneStar);
        
        if (_timer.RunnigTime < _timeForTwoStar)
            if (TryGetKeyStars(_twoStar))
                SetStars(_twoStar);          

        if (_timer.RunnigTime < _timeForThreeStar)
            if (TryGetKeyStars(_threeStar))
                SetStars(_threeStar);
    }

    private bool TryGetKeyStars(int value)
    {
        return PlayerPrefs.GetInt(_keyStars) < value;
    }

    private void SetStars(int value)
    {
        PlayerPrefs.SetInt(_keyStars, value);
    }
}
