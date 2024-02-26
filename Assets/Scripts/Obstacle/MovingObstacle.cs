using DG.Tweening;
using UnityEngine;

public class MovingObstacle : Obstacle
{
    [SerializeField] private float _distanceMove;
    [SerializeField] private float _speed;

    protected override void Move()
    {
        float distance = transform.position.y + _distanceMove;
        transform.DOMoveY(distance, _speed).SetLoops(-1, LoopType.Yoyo);
    }
}
