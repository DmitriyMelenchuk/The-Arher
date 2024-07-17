using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : Bar
{
    [SerializeField] private Vector3 _offset;

    protected override Vector3 GetPosition()
    {
        return Slider.transform.position = transform.parent.position + _offset;
    }

    protected override IDamageable Init(IDamageable damageable)
    {
        return GetComponentInParent<Enemy>()._damageable;
    }
}
