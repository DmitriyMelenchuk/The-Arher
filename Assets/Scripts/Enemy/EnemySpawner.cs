using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _capacity;

    private ObjectPool<Enemy> _pool;

    public void Init(MoneyCounter moneyCounter, Transform target)
    {
        _pool = new ObjectPool<Enemy>(_prefab, _container, _capacity);

        foreach (var point in _spawnPoint)
        {
            Enemy enemy = Create();
            enemy.transform.position = point.transform.position;
            enemy.GetComponentInChildren<EnemyBow>().Init(target);
            enemy.GetComponent<Reward>().Init(moneyCounter);
        } 
    }

    public Enemy Create()
    {
        Enemy enemy = _pool.GetObject();
        return enemy;
    }

    public Enemy[] GetEnemies()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        return enemies;
    }
}
