using System;
using UnityEngine;

public class RewardForLevel : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private MoneyWallet _moneyWallet;

    public event Action<int> ChangedReward;

    private void Start()
    {
        _moneyWallet.Add(_value);
        ChangedReward?.Invoke(_value);
    }
}
