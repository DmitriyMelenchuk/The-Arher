using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    public IDamageable _damageable { private set; get; }

    public event Action Died;
    public event Action<int> ChangedHealth;
    public event Action<int> TakedDamage;

    public int Health => _health;

    private void Awake()
    {
        _damageable = new EnemyHealth(_health);
    }

    public void TakeDamage(int damage)
    {
        _damageable.TakeDamage(damage);
    }
}
