using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    private IDamageable _iDamageable;

    private void Start()
    {
        _iDamageable = Init(_iDamageable);
        Slider.maxValue = _iDamageable.Health;
        Slider.value = _iDamageable.Health;
        Slider.transform.position = GetPosition(); 
        _iDamageable.ChangedHealth += OnTakedDamage;
    }
    
    protected abstract IDamageable Init(IDamageable damageable);

    private void OnDisable()
    {
        if (_iDamageable != null)
        {
            _iDamageable.ChangedHealth -= OnTakedDamage;
            Debug.Log(_iDamageable.Health);
        } 
    }

    protected virtual void OnTakedDamage(int value)
    {
        Slider.value = value; 
    }

    protected abstract Vector3 GetPosition();
}
