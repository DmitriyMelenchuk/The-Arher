using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Creature : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    private int _maxHealth;

    public int Health => _health; 
    protected Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public event Action Died;
    public event Action<int> TakedDamage;
    public event Action ChangedHealth;

    private void OnEnable()
    {
        Died += OnDie;
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    private void OnDisable()
    {
        Died -= OnDie;
    }

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

    public void Reset()
    {
        _health = _maxHealth;
        ChangedHealth?.Invoke();
    }

    public void AddHealth(int value)
    {
        if (value > 0)
        {
            if (_health + value <= _maxHealth)
                _health += value;
            else
                _health = _maxHealth;

            ChangedHealth?.Invoke();
        } 
    }

    protected abstract void OnDie();
}
