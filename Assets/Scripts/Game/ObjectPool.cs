using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> _pool;
    private Transform _container;
    private T _prefab;

    public ObjectPool(T prefab,Transform container, int capacity)
    {
        _container = container;
        _prefab = prefab;
        _pool = new List<T>();

        for (int i = 0; i < capacity; i++)
        {
            CreateObject();
        }
    }

    public T GetObject()
    {
        T spawned = _pool.FirstOrDefault(x => x.isActiveAndEnabled != true);

        if (spawned == null)
            spawned = CreateObject();

        spawned.gameObject.SetActive(true);
        return spawned;
    }

    private T CreateObject()
    {
        T spawned = Object.Instantiate(_prefab, _container);
        spawned.gameObject.SetActive(false);
        _pool.Add(spawned);
        return spawned;
    }  
}
