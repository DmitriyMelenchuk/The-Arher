using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private MoneyWallet _moneyWallet;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _capacity;

    private ObjectPool<Enemy> _pool;

    public void Init(Transform target)
    {
        _pool = new ObjectPool<Enemy>(_prefab, _container, _capacity);

        foreach (var point in _spawnPoint)
        {
            Enemy enemy = Create();
            enemy.transform.position = point.transform.position;
            enemy.GetComponentInChildren<EnemyBow>().Init(target);
            enemy.GetComponent<Reward>().Init(_moneyWallet);
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
