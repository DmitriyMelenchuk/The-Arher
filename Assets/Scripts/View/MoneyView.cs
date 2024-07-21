using TMPro;
using UnityEngine;

public class MoneyView : MonoBehaviour
{
    [SerializeField] private MoneyWallet _moneyCounter;
    [SerializeField] private TMP_Text _money;

    private void OnEnable()
    {
        _moneyCounter.MoneyChanged += OnScoreChanged;
    }

    private void Start()
    {
        _money.text = _moneyCounter.Money.ToString();
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
