using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private ShotingTrajectory _shotingTrajectory;
    [SerializeField] private Transform _shotingTransform;
    [SerializeField] private PlayerBow _weapon;

    private Animator _animator;
    private PlayerInput _playerInput;
    private float _minForceShot = 5f;
    private float _maxForceShot = 15f;
    private float _forceShot;

    public bool IsStartShoting { get; private set; }

    private void OnEnable()
    {
        _playerInput.ShotStarting += OnShotStarting;
        _playerInput.ShotEnded += OnShotEnded;
    }

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsStartShoting == true)
        {           
            if (_forceShot <= _maxForceShot)
                _forceShot += _maxForceShot * Time.deltaTime;

            DrawTrajectory();
        }
    }

    private void OnDisable()
    {
        _playerInput.ShotStarting -= OnShotStarting;
        _playerInput.ShotEnded -= OnShotEnded;
    }

    private void DrawTrajectory()
    {
        _shotingTrajectory.Activated();
        _shotingTrajectory.Draw(_weapon.transform.position, _weapon.transform.right * _forceShot);
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
        _shotingTrajectory.Deactivated();
        _forceShot = _minForceShot;
    }   
}
