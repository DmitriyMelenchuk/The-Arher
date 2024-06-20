using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Reward : MonoBehaviour
{
    [SerializeField] private int _reward;
    [SerializeField] private MoneyCounter _moneyCounter;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _enemy.Died += OnDied;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnDied;
    }

    private void OnDied()
    {
        _moneyCounter.Add(_reward);
    }
}
