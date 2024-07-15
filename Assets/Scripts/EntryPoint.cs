using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private ObstacleSpawner _obstacleStaticSpawner;
    [SerializeField] private ObstacleSpawner _obstacleMovingSpawner;
    [SerializeField] private MoneyCounter _moneyCounter;
    [SerializeField] private EnemySpawner _enemySpawner;


    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _player.Init(_playerInput, _playerHand, _playerShoting);
        _enemySpawner.Init(_moneyCounter,_player.transform);
        _obstacleStaticSpawner.Init();
        _obstacleMovingSpawner.Init();
    }
}
