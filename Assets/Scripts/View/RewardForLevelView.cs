using TMPro;
using UnityEngine;

public class RewardForLevelView : MonoBehaviour
{
    private const string Symbol = "+";

    [SerializeField] private RewardForLevel _rewardForLevel;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _rewardForLevel.ChangedReward += OnChangedReward;
    }

    private void OnDisable()
    {
        _rewardForLevel.ChangedReward -= OnChangedReward;
    }

    private void OnChangedReward(int value)
    {
        _text.text = Symbol + value.ToString();
    }
}
