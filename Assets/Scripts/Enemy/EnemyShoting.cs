using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private Transform _shotingTransform;
    [SerializeField] private EnemyBow _weapon;
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private float _timeBeforeShot;

    private Animator _animator;
    private float _forceShot = 15;
    private float _runnigTime;

    private void OnEnable()
    {
        _enemyHand.EndedRotation += OnEndedRotation;
    }
 
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Shot();
    }

    private void OnDisable()
    {
        _enemyHand.EndedRotation -= OnEndedRotation;
    }

    public void Shot()
    {
        _runnigTime += Time.deltaTime;

        if (_runnigTime >= _timeBeforeShot)
        {
            _weapon.CreateArrow();
            _animator.SetBool(IsShot, true);
            _enemyHand.Rotate();
            _runnigTime = 0;
        }
    }

    private void OnEndedRotation()
    {
        _weapon.Shot(_forceShot);
    }
}
