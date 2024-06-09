using UnityEngine;

public class Player : Creature
{
    private PlayerShoting _playerShoting;
    private PlayerInput _playerInput;
    private PlayerHand _playerHand;

    private void Update()
    {
        if (_playerShoting.IsStartShoting == true)
            _playerHand.Rotate(_playerInput.MousePosition);
    }

    public void Init(PlayerInput playerInput, PlayerHand playerHand, PlayerShoting playerShoting)
    {
        _playerInput = playerInput;
        _playerShoting = playerShoting;
        _playerHand = playerHand;
    }

    protected override void OnDie()
    {
        gameObject.SetActive(false);
    }
}
