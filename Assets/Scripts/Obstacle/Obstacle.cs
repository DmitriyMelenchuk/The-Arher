using System;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{
    private IDamageable _damageable;
    private IMovable _movable;

    public IDamageable IDamageable => _damageable;
    public IMovable IMovable => _movable;

    public event Action Died;
    public event Action<int> TakedDamage;
   
    protected void Init(IDamageable damageable, IMovable movable)
    {
        _damageable = damageable;
        _movable = movable;
    }
    private void Start()
    {
        Move();
    }

    private void OnEnable()
    {
        IDamageable.TakedDamage += OnTakeDamage;
        IDamageable.Died += OnDied;
    }

    private void OnDisable()
    {
        IDamageable.TakedDamage -= OnTakeDamage;
        IDamageable.Died -= OnDied;
    }

    private void OnTakeDamage(int damage)
    {
        TakedDamage?.Invoke(damage);
    }

    private void OnDied()
    {
        Died?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _damageable.TakeDamage(damage);
    }

    private void Move()
    {
        _movable.Move();
    }
}
