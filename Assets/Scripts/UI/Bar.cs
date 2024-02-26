using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    private IDamageable _iDamageable;

    private void Awake()
    {
        _iDamageable = GetComponentInParent<IDamageable>();
         Slider.maxValue = _iDamageable.Health;
        Slider.value = _iDamageable.Health;
        Slider.transform.position = GetPosition();
    }
    
    private void OnEnable()
    {
        _iDamageable.ChangedHealth += OnTakedDamage;
    }

    private void OnDisable()
    {
        _iDamageable.ChangedHealth -= OnTakedDamage;
    }

    protected virtual void OnTakedDamage()
    {
        Slider.value = _iDamageable.Health; 
    }

    protected abstract Vector3 GetPosition();
}
