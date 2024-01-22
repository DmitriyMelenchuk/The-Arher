using UnityEngine;

public class ObstacleHealthBar : Bar
{
    [SerializeField] private Vector3 _offset;

    protected override Vector3 GetPosition()
    {
        return Slider.transform.position = transform.parent.position + _offset;
    }
}
