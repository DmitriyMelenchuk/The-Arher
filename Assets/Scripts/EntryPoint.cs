using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private PlayerHand _playerHand;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _player.Init(_enemy);
        _playerInput.Init();
        _enemy.Init(_player);
    }
}
