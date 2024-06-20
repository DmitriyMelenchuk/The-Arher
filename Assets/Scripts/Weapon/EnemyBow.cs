using UnityEngine;

public class EnemyBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private Transform target;
    [SerializeField] private int _damage;

    private Arrow _currentArrow;
    private float _angleRotateArrow = 180;

    private float _minForce = 3;
    private float _maxForce = 7;

    private void Update()
    {
        if (_currentArrow != null)
            if (_currentArrow.enabled == true)
                _currentArrow.RotateTo(_angleRotateArrow + _enemyHand.transform.eulerAngles.x);
    }

    public void Shot(float forceShot)
    {
        Vector3 heading = target.position - transform.position;
        float distance = heading.magnitude;
        Vector3 direction = new Vector3(heading.x, heading.y + GetRandomValue(), heading.z) / distance;

        _currentArrow.Move(direction, forceShot);
    }

    public void CreateArrow()
    {
        if (_currentArrow != null)
            _currentArrow.gameObject.SetActive(false);

        if (Time.timeScale != 0)
        {
            _currentArrow = _arrowSpawner.Create();
            _currentArrow.SetToHand(transform);
            _currentArrow.InitDamage(_damage);
        }
    }

    private float GetRandomValue()
    {
        float value = Random.Range(_minForce, _maxForce);
        return value;
    }
}
