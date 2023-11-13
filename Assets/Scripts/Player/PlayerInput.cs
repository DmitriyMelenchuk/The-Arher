using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerAction _playerInput;

    public Vector2 MousePosition => _playerInput.Player.MousePosition.ReadValue<Vector2>();

    public event Action ShotStarting;
    public event Action ShotEnded;
   
    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void Start()
    {
        _playerInput.Player.Shoot.performed += ctx => OnStartShooting();
        _playerInput.Player.Shoot.canceled += ctx => OnShootEnded();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void Init()
    {
        _playerInput = new PlayerAction();
    }

    private void OnStartShooting()
    {
        ShotStarting?.Invoke();
    }

    private void OnShootEnded()
    {
        ShotEnded?.Invoke();
    }
}
