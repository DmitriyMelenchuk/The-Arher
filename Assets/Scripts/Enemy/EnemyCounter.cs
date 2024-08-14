using System;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private Enemy[] _enemies;
    private int _count;

    public int Count { private set; get; }

    public event Action EnemiesAreOver;
    public event Action ChangedCountEnemys;

    private void Awake()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        _count = _enemies.Length;
        Count = _count;

        for (int i = 0; i < _enemies.Length; i++)
            _enemies[i]._damageable.Died += OnDied;
    }

    private void Disable()
    {
        for (int i = 0; i < _enemies.Length; i++)
            _enemies[i]._damageable.Died -= OnDied;
    }

    private void OnDied()
    {
        _count--;
        ChangedCountEnemys?.Invoke();

        if (_count == 0)
            EnemiesAreOver?.Invoke();   
    }
}
