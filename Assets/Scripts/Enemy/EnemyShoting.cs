using UnityEngine;

public class EnemyShoting : MonoBehaviour
{
    [SerializeField] private Transform _shotingTransform;
    [SerializeField] private EnemyBow _weapon;
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private float _timeToShot = 2;

    private float _forceShot = 15;
    private float _runningTime;

    private void Update()
    {
        _runningTime += Time.deltaTime;
        _enemyHand.Rotate();

        if (_runningTime >= _timeToShot)
        {
            _enemyHand.SetRandomPositionY();
            _weapon.Shot(_forceShot);
            _runningTime = 0;
        }
    }
}
