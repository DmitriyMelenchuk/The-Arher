using TMPro;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private TextMeshPro _prefab;
    [SerializeField] private int _capacity;
     
    private ObjectPool<TextMeshPro> _pool;

    private void Start()
    {
        _pool = new ObjectPool<TextMeshPro>(_prefab, _container, _capacity);
    }

    public void Create(Vector3 position, int value)
    {
        var text = _pool.GetObject();
        text.text = "-" + value.ToString();
        text.rectTransform.position = position;
    }
}
