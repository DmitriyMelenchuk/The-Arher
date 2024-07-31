using System;
using UnityEngine;

public class PlayerBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;
    [SerializeField] private Player _player;
    [SerializeField] private AudioSource _audioSource;

    private Arrow _currentArrow;

    public event Action Shoot;

    private void Update()
    {
        if (_currentArrow != null)
            if (_currentArrow.enabled == true)
                _currentArrow.RotateTo(transform.localRotation.z);
    }

    public void Shot(float forceShot)
    {
        if (Time.timeScale != 0)
        {
            _currentArrow.Move(transform.right, forceShot);
            _audioSource.Play();
        }  
    }

    public void CreateArrow()
    {
        if (Time.timeScale != 0)
        {
            _currentArrow = _arrowSpawner.Create();
            _currentArrow.SetToHand(transform);
            _currentArrow.InitDamage(_player.PlayerDamage.Damage);
        }           
    }
}
