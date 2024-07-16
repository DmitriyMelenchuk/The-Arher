using UnityEngine;

public class PlayerHealthBar : Bar
{
    [SerializeField] private Transform _transform;

    protected override Vector3 GetPosition()
    {
        return Slider.transform.position = _transform.position;
    }

    protected override IDamageable Init(IDamageable damageable)
    {
        return GetComponentInParent<Player>()._damageable;
    }
}
