using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private Transform _leftHand;
    [SerializeField] private float _speedRotation;

    private float _timeRotation = 1f;
    private float _rotationTime;

    private float _minRotation = -1;
    private float _maxRotation = 20;


    public event Action StartingRotation;
    public event Action<float> EndedRotation;

    private void Update()
    {
        transform.position = _leftHand.position;
    }

    public float GetRandomPositionY()
    {
        float value = Random.Range(_minRotation, _maxRotation);
        return value;
    }

    public void Rotate()
    {
        StartCoroutine(DelayRotation());
    }

    private IEnumerator DelayRotation()
    {
        Vector3 targetPosition = new Vector3(0, GetRandomPositionY(), 0);
        Vector3 direction = targetPosition - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        StartingRotation?.Invoke();

        while (_rotationTime <= _timeRotation)
        {
            _rotationTime += Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(
            Quaternion.Euler(new Vector3(transform.eulerAngles.x, 0f, 0f)),
            Quaternion.Euler(new Vector3(targetRotation.x * _speedRotation, 0f, 0f)), _maxRotation);
            yield return null;
        }

        EndedRotation?.Invoke(targetPosition.y);
        _rotationTime = 0;
    }
}
