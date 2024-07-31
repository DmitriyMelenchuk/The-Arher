using UnityEngine;

public class ShootAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private IWeapon _weapon;

    private void Awake()
    {
        _weapon = GetComponent<IWeapon>();
    }

    private void OnEnable()
    {
        _weapon.Shoot += OnShoot;
    }

    private void OnDisable()
    {
        _weapon.Shoot -= OnShoot;
    }

    private void OnShoot()
    {
        _audioSource.Play();
    }
}