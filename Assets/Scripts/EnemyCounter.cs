using System;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    private Enemy[] _enemies;
    private int _count;

    public event Action EnemiesAreOver;

    private void Start()
    {
        _enemies = gameObject.GetComponentsInChildren<Enemy>();
        _count = _enemies.Length;

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

        if (_count == 0)
            EnemiesAreOver?.Invoke();   
    }
}
