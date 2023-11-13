using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ShotingTrajectory _shotingTrajectory;
    [SerializeField] private PlayerHand _playerHand;
    [SerializeField] private Transform _shotingTransform;
    [SerializeField] private PlayerBow _weapon;

    private float _forceShot;
    private float _maxForceShot = 15f;
    private bool _isStartShoting;

    private void OnEnable()
    {
        _playerInput.ShotStarting += OnShotStarting;
        _playerInput.ShotEnded += OnShotEnded;
    }

    private void Update()
    {
        if (_isStartShoting == true)
        {
            if (_forceShot <= _maxForceShot)
                _forceShot += _maxForceShot * Time.deltaTime;

            _playerHand.Rotate(_playerHand.transform, _playerInput.MousePosition);
            DrawTrajectory();
        }
    }

    public void Init(PlayerInput playerInput)
    {
        _playerInput = playerInput;
    }

    private void DrawTrajectory()
    {
        _shotingTrajectory.Activated();
        _shotingTrajectory.Draw(_weapon.transform.position, _weapon.transform.right * _forceShot);
    }

    private void OnShotStarting()
    {
        _isStartShoting = true;
    }

    private void OnShotEnded()
    {
        _weapon.Shot(_forceShot);
        _isStartShoting = false;
        _shotingTrajectory.Deactivated();
        _forceShot = 0;
    }   
}
