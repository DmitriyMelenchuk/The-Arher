using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _capacity;

    private ObjectPool<Enemy> _pool;

    public void Init()
    {
        _pool = new ObjectPool<Enemy>(_prefab, _container, _capacity);

        foreach (var point in _spawnPoint)
            Create().transform.position = point.transform.position;
    }

    public Enemy Create()
    {
        Enemy enemy = _pool.GetObject();
        return enemy;
    }
}
