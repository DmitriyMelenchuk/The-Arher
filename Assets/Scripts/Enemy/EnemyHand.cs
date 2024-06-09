using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private Transform _leftHand;
    [SerializeField] private float _speedRotation;

    private float _timeRotation = 1f;
    private float _runnigTime;
    private float _rotationTime;

    private float _minRotation = -1;/*-16f;*/
    private float _maxRotation = 20;/*35f;*/

    public event Action StartingRotation;
    public event Action<float> EndedRotation;

    private void Update()
    {
        transform.position = _leftHand.position;
        Rotate();
    }

    public float GetRandomPositionY()
    {
        float value = Random.Range(_minRotation, _maxRotation);
        return value;
    }

    public void Rotate()
    {
        _runnigTime += Time.deltaTime;

        if (_runnigTime >= 3)
        {
            StartCoroutine(DelayRotation());
            _runnigTime = 0;
        }
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
        Debug.Log(targetPosition.y);
        EndedRotation?.Invoke(targetPosition.y);
        _rotationTime = 0;
    }
}
