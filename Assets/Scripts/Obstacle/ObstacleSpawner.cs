using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnPoint;
    [SerializeField] private Transform _container;
    [SerializeField] private Obstacle _prefab;
    [SerializeField] private int _capacity;

    private ObjectPool<Obstacle> _pool;

    public void Init()
    {
        _pool = new ObjectPool<Obstacle>(_prefab, _container, _capacity);

        foreach (var point in _spawnPoint)
            Create().transform.position = point.transform.position;
    }

    public Obstacle Create()
    {
        Obstacle obstacle = _pool.GetObject();
        return obstacle;
    }
}
