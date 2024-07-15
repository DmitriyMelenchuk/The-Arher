using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Reward : MonoBehaviour
{
    [SerializeField] private int _count;
    private MoneyCounter _moneyCounter;

    private Enemy _enemy;

    public int Count => _count;

    public void Init(MoneyCounter moneyCounter)
    {
        _moneyCounter = moneyCounter;
    }

    private void OnEnable()
    {
        _enemy = GetComponent<Enemy>();
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        _moneyCounter.Add(_count);
    }
}