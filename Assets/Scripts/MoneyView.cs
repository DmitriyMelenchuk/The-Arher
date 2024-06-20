using System;
using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        _moneyCounter.MoneyChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _moneyCounter.MoneyChanged -= OnScoreChanged; 
    }

    private void OnScoreChanged(int money)
    {
        _money.text = money.ToString();
    }
}
