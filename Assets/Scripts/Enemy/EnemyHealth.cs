using System;

public class EnemyHealth : IDamageable
{
    public int Health { private set; get; }

    public event Action Died;
    public event Action<int> ChangedHealth;
    public event Action<int> TakedDamage;

    public EnemyHealth(int value)
    {
        Health = value;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        TakedDamage?.Invoke(damage);
        ChangedHealth?.Invoke(Health);

        if (Health < 0)
            Health = 0;

        if (Health == 0)
            Died?.Invoke();
    }
}
