using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Creature : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private int _startHealth;

    public int Damage => _damage;
    public int Health => _health; // +
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
        _startHealth = _health;
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
        _health = _startHealth;
        ChangedHealth?.Invoke();
    }

    protected abstract void OnDie();

    protected abstract void OnCollisionEnter(Collision collision);
}
