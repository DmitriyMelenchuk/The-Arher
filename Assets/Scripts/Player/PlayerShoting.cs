using System;
using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private PlayerBow _weapon;

    private Animator _animator;
    private PlayerInput _playerInput;
    private float _minForceShot = 5f;
    private float _maxForceShot = 15f;
    private float _forceShot;

    public bool IsStartShoting { get; private set; }

    public event Action<float> ChangedForceShot;
    public event Action EndedShooting;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.ShotStarting += OnShotStarting;
        _playerInput.ShotEnded += OnShotEnded;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (IsStartShoting == true)
        {
            if (_forceShot <= _maxForceShot)
                _forceShot += _maxForceShot * Time.deltaTime;
            ChangedForceShot?.Invoke(_forceShot);
        }
    }

    private void OnDisable()
    {
        _playerInput.ShotStarting -= OnShotStarting;
        _playerInput.ShotEnded -= OnShotEnded;
    }

    private void OnShotStarting()
    {
        IsStartShoting = true;
        _weapon.CreateArrow();
        _animator.SetBool(IsShot, true);       
    }

    private void OnShotEnded()
    {
        _animator.SetBool(IsShot, false);
        _weapon.Shot(_forceShot);
        IsStartShoting = false;
        _forceShot = _minForceShot;
        ChangedForceShot?.Invoke(_forceShot);
        EndedShooting?.Invoke();
    }   
}
