using UnityEngine;

public class StaticObstacle : Obstacle
{
    [SerializeField] private int _health;

    private void Awake()
    {
        Init(new HealthObstacle(_health), new NoMoveObstacleBehaviour());
    }
}
