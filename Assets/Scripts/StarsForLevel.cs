using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsForLevel : MonoBehaviour
{
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

    private void OnDisable()
    {
        _enemyCounter.EnemiesAreOver -= OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        StringBuilder stringBuilder = new StringBuilder("stars");
        string starsKey = stringBuilder.Append(SceneManager.GetActiveScene().buildIndex).ToString();
        Debug.Log(starsKey);
        PlayerPrefs.SetInt(starsKey, _oneStar);

        if (_timer.RunnigTime < _timeForTwoStar)
        {
            PlayerPrefs.SetInt(starsKey, _twoStar);
            Debug.Log("2 stars");
        }

        if (_timer.RunnigTime < _timeForThreeStar)
        {
            PlayerPrefs.SetInt(starsKey, _threeStar);
            Debug.Log("3 stars");
        }
    }

}
