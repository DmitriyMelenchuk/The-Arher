using DG.Tweening;
using UnityEngine;

public class MovingObstacle : Obstacle
{
    [SerializeField] private float _distanceMove;
    [SerializeField] private float _speed;
    //[SerializeField] private int _health;

    //protected override void InitPatterns()
    //{
    //    _movable = new PatrolMovePattern(_distanceMove, transform, _speed);
    //    _damageable = new DamageablePattern(_health);
    //}

    protected override void Move()
    {
        float distance = transform.position.y + _distanceMove;
        transform.DOMoveY(distance, _speed).SetLoops(-1, LoopType.Yoyo);
    }
}
