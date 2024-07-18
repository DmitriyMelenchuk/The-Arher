using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Reward : MonoBehaviour
{
    [SerializeField] private int _count;

    private MoneyWallet _moneyWallet;
    private Enemy _enemy;

    public int Count => _count;

    public void Init(MoneyWallet moneyWallet)
    {
        _moneyWallet = moneyWallet;
    }

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _enemy._damageable.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy._damageable.Died -= OnDied;
    }

    private void OnDied()
    {
        _moneyWallet.Add(_count);
    }
}