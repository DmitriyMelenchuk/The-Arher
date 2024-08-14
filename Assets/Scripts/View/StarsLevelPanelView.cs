using System.Text;
using TMPro;
using UnityEngine;

public class StarsLevelPanelView : MonoBehaviour
{
    [SerializeField] private StarsForLevel _starsForLevel;
    [SerializeField] private TMP_Text _oneStarText;
    [SerializeField] private TMP_Text _twoStarText;
    [SerializeField] private TMP_Text _threeStarText;

    private int _countDiedEnemy;
    private int _maxCountEnemy;

    private void Start()
    {
        _oneStarText.text = _starsForLevel.TimeForTwoStar.ToString();
        _maxCountEnemy = _starsForLevel.EnemyCounter.Count;
        SetTextOneStar();
        SetTimeStarText(_twoStarText.text, _starsForLevel.TimeForTwoStar);
        SetTimeStarText(_threeStarText.text, _starsForLevel.TimeForThreeStar);
        _starsForLevel.EnemyCounter.ChangedCountEnemys += OnChangedCountEnemys;
    }

    private void OnDisable()
    {
        _starsForLevel.EnemyCounter.ChangedCountEnemys -= OnChangedCountEnemys;
    }

    private void OnChangedCountEnemys()
    {
        _countDiedEnemy++;
        SetTextOneStar();
    }

    private void SetTextOneStar()
    {
        StringBuilder stringBuilder = new StringBuilder("-" + _countDiedEnemy + "/" + _maxCountEnemy);
        _oneStarText.text = stringBuilder.ToString();
    }

    private void SetTimeStarText(string text, int time)
    {
        StringBuilder stringBuilder = new StringBuilder("-" + time + "сек.");
        text = stringBuilder.ToString();
    }
}
