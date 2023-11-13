using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private int _healthValue;
    [SerializeField] private int _damageValue;

    private Enemy _enemy;
    private Health _health;

    public int DamageValue => _damageValue;

    private void OnEnable()
    {
        _health.Die += OnDie;
    }

    private void OnDisable()
    {
        _health.Die -= OnDie;
    }

    public void Init(Enemy enemy)
    {
        _health = new Health(_healthValue);
        _enemy = enemy;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage + _enemy.DamageValue);
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
    }
}
