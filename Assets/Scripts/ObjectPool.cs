using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private Transform _container;
    private T _prefab;
    private readonly List<T> _pool;

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

    public void Release(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    private T CreateObject()
    {
        T spawned = GameObject.Instantiate(_prefab, _container);
        spawned.gameObject.SetActive(false);
        _pool.Add(spawned);
        return spawned;
    }
}
