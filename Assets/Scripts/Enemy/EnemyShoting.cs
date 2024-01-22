using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private Transform _shotingTransform;
    [SerializeField] private EnemyBow _weapon;
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private float _timeToShot = 2;

    private Animator _animator;
    private float _forceShot = 15;
    private float _runningTime;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Shoot()
    {
        _runningTime += Time.deltaTime;
        _enemyHand.Rotate();
        _animator.SetBool(IsShot, false);

        if (_runningTime >= _timeToShot)
        {
            _animator.SetBool(IsShot, true);
            _enemyHand.SetRandomPositionY();
            _weapon.Shot(_forceShot);
            _runningTime = 0;
        }
    }
}
