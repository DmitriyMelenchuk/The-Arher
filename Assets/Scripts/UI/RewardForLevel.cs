using System;
using UnityEngine;

public class RewardForLevel : MonoBehaviour
{
    [SerializeField] private int _value;

    public event Action<int> ChangedReward;

    private void Start()
    {
        ChangedReward?.Invoke(_value);
    }
}
