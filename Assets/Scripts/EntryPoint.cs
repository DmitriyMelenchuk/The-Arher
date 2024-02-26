using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private EnemyShoting _enemyShoting;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private ObstacleSpawner _obstacleStaticSpawner;
    [SerializeField] private ObstacleSpawner _obstacleMovingSpawner;


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _player.Init(_playerInput, _playerHand, _playerShoting);
        _enemy.Init(_enemyShoting);
        _obstacleStaticSpawner.Init();
        _obstacleMovingSpawner.Init();
    }
}
