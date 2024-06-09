using UnityEngine;

public class ShootingTrajectory : MonoBehaviour
{
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private PlayerBow _weapon;
    [SerializeField] private RenderTrajectory _shotingTrajectory;
    [SerializeField] private Transform _shotingTransform;

    private void OnEnable()
    {
        _playerShoting.ChangedForceShot += OnChangedForceShot;
        _playerShoting.EndedShooting += OnEndedShooting;
    }

    private void OnDisable()
    {
        _playerShoting.ChangedForceShot -= OnChangedForceShot;
        _playerShoting.EndedShooting -= OnEndedShooting;
    }

    private void OnEndedShooting()
    {
        _shotingTrajectory.Deactivated();
    }

    private void OnChangedForceShot(float value)
    {
        _shotingTrajectory.Activated();
        _shotingTrajectory.Draw(_weapon.transform.position, _weapon.transform.right * value);
    }
}