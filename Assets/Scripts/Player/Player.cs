using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;

    private PlayerShoting _playerShoting;
    private PlayerInput _playerInput;
    private PlayerHand _playerHand;
    public IDamageable _damageable { private set; get; }

    public event Action Died;
    public event Action<int> ChangedHealth;
    public event Action<int> TakedDamage;

    public int Health => _health;

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (_playerShoting.IsStartShoting == true)
            _playerHand.Rotate(_playerInput.MousePosition);
    }

    public void Init(PlayerInput playerInput, PlayerHand playerHand, PlayerShoting playerShoting)
    {
        _playerInput = playerInput;
        _playerShoting = playerShoting;
        _playerHand = playerHand;
        _damageable = new PlayerHealth(_health);
    }

    public void TakeDamage(int damage)
    {
        _damageable.TakeDamage(damage);
    }
}
