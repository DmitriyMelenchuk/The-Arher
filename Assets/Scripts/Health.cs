using System;

public class Health : IDamageable
{
    public Health(float value)
    {
        Value = value;
    }

    public float Value { get; private set; }

    public event Action Die;

    public void TakeDamage(int damage)
    {
        Value -= damage;

        if (Value <= 0)
        {
            Value = 0;
            Die?.Invoke();
        }           
    }
}
