using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private EnemyBow _weapon;
    [SerializeField] private EnemyHand _enemyHand;

    private Animator _animator;
    private float _forceShot = 15f;
    private float _runnigTime;
    private int _timeBetweenShot;
    private int _minTimeBetweenShot = 1;
    private int _maxTimeBetweenShot = 5;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _timeBetweenShot = GetRandomTimeToShot();
    }

    private void OnEnable()
    {
        _enemyHand.StartingRotation += OnStartedShot;
        _enemyHand.EndedRotation += OnEndedShot;
    }

    private void Update()
    {
        _runnigTime += Time.deltaTime;

        if (_runnigTime >= _timeBetweenShot)
        {
            _enemyHand.Rotate();
            _timeBetweenShot = GetRandomTimeToShot();
            _runnigTime = 0;
        }
    }

    private void OnDisable()
    {
        _enemyHand.StartingRotation -= OnStartedShot;
        _enemyHand.EndedRotation -= OnEndedShot;
    }

    public int GetRandomTimeToShot()
    {
        int value = Random.Range(_minTimeBetweenShot, _maxTimeBetweenShot);
        return value;
    }

    private void OnStartedShot()
    {
        _animator.SetBool(IsShot, true);
        _weapon.CreateArrow();
    }

    private void OnEndedShot(float value)
    {
        _animator.SetBool(IsShot, false);
        _weapon.Shot(_forceShot);
    }
}
