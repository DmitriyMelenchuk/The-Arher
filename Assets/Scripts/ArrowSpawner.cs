using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Arrow _prefab;
    [SerializeField] private int _capacity;

    private ObjectPool<Arrow> _pool;

    private void Start()
    {
        _pool = new ObjectPool<Arrow>(_prefab, _container, _capacity);
    }

    public Arrow CreateArrow()
    {
        var arrow = _pool.GetObject();
        return arrow;
    }
}
