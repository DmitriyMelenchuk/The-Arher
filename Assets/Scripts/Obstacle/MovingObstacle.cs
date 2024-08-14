using UnityEngine;

public class MovingObstacle : Obstacle
{
    [SerializeField] private int _health;
    [SerializeField] private float _distanceMove;
    [SerializeField] private float _speed;

    private void Awake()
    {
        Init(new HealthObstacle(_health), new MoveObstacleBehaviour(_speed, _distanceMove, transform));
    }
}
