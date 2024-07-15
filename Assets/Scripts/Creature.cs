using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Creature : MonoBehaviour, IDamageable
{
    private static string _keyHealth = "health";

    [SerializeField] private int _health;

    private int _maxHealth;

    public int Health => _health; 

    protected Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public event Action Died;
    public event Action<int> TakedDamage;
    public event Action<int> ChangedHealth;

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
        ChangedHealth?.Invoke(_health);

        if (_health <= 0)
        {
            _health = 0;
            Died?.Invoke();
        }
    }

    public void SetMaxHealth(int value)
    {

    }

    public void AddHealth(float value)
    {
        int health = (int)(value * _maxHealth);

         if (_health + health <= _maxHealth)
             _health += health;
         else
             _health = _maxHealth;
       
        ChangedHealth?.Invoke(_health);
    }

    protected abstract void OnDie();
}
