using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _healthValue;
    [SerializeField] private int _damageValue;

    private Player _player;
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

    public void Init(Player player)
    {
        _health = new Health(_healthValue);
        _player = player;
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage + _player.DamageValue);
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
    }
}
