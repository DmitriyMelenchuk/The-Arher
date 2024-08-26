using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private MoneyWallet _moneyCounter;
    [SerializeField] private TMP_Text _moneyPlayer;

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
        _moneyPlayer.text = money.ToString();
    }
}
