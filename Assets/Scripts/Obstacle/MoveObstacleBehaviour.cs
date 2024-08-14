using DG.Tweening;
using UnityEngine;

public class MoveObstacleBehaviour : IMovable
{
    private float _distanceMove;
    private float _speed;
    private Transform _transform;

    public MoveObstacleBehaviour(float speed, float distanceMove, Transform transform)
    {
        _speed = speed;
        _distanceMove = distanceMove;
        _transform = transform;
    }

    public void Move()
    {
        float distance = _transform.position.y + _distanceMove;
        _transform.DOMoveY(distance, _speed).SetLoops(-1, LoopType.Yoyo);
    }
}
