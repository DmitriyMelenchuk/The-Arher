using UnityEngine;

public class ShootingTrajectory : MonoBehaviour
{
    [SerializeField] private PlayerShoting _playerShoting;
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private RenderTrajectory _shotingTrajectory;

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
        _shotingTrajectory.Draw(_weaponTransform.position, _weaponTransform.right * value);
    }
}
