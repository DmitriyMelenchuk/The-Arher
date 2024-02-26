using System;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour, IDamageable
{
    [SerializeField] private DamageTextSpawner _textSpawner;
    [SerializeField] private int _health;

    private int _startHealth;

    public event Action Died;
    public event Action ChangedHealth;
    public event Action<int> TakedDamage;

    public int Health => _health;

    private void Start()
    {
        Move();
        _startHealth = _health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Arrow arrow))
        {
            int damage = arrow.Creature.Damage;
            TakeDamage(damage); 
        }
    }

    public void Reset()
    {
        _health = _startHealth;
    }

    protected virtual void Move() { }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        TakedDamage?.Invoke(damage);
        ChangedHealth?.Invoke();

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }
}
