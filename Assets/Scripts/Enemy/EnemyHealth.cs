using System;

public class EnemyHealth : IDamageable
{
    private int _health;

    public int Health { private set; get; }

    public event Action Died;
    public event Action<int> ChangedHealth;
    public event Action<int> TakedDamage;

    public EnemyHealth(int value)
    {
        _health = value;
        Health = _health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        TakedDamage?.Invoke(damage);
        ChangedHealth?.Invoke(_health);

        if (_health < 0)
            _health = 0;

        if (_health == 0)
            Died?.Invoke();
    }
}
