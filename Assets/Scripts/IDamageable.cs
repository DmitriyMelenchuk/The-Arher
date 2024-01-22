using System;

public interface IDamageable 
{
    public int Health { get; } // +

    public event Action Died;
    public event Action ChangedHealth; // +
    public event Action<int> TakedDamage;
    public void TakeDamage(int damage);
}
