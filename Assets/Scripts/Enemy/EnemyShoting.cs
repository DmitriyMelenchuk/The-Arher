using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyShoting : MonoBehaviour
{
    private const string IsShot = nameof(IsShot);

    [SerializeField] private EnemyBow _weapon;
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private float _timeBeforeShot;

    private Animator _animator;
    private float _forceShot = 15f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _enemyHand.StartingRotation += OnStartedShot;
        _enemyHand.EndedRotation += OnEndedShot;
    }

    private void OnDisable()
    {
        _enemyHand.StartingRotation -= OnStartedShot;
        _enemyHand.EndedRotation -= OnEndedShot;
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
