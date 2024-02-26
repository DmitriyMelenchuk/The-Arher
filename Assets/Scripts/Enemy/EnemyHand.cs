using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private PlayerShoting _target;
    [SerializeField] private float _speedRotation;

    private float _timeRotation = 0.5f;
    private float _runnigTime;

    private int _minRotation = 3;
    private int _maxRotation = 15;

    public event UnityAction EndedRotation;

    public float GetRandomPositionY()
    {
        return Random.Range(_minRotation, _maxRotation);
    }

    public void Rotate()
    {
        StartCoroutine(DelayRotation());
        _runnigTime = 0;
    }

    private IEnumerator DelayRotation()
    {
        float positionY = _target.transform.position.y + GetRandomPositionY();
        Vector3 direction = new Vector3(_target.transform.position.x, positionY, _target.transform.position.z) - transform.position;

        while (_timeRotation >= _runnigTime)
        {            
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
            _runnigTime += Time.deltaTime;
            yield return null;
        }

        EndedRotation?.Invoke();
    }


    //public void Rotate()
    //{
    //    StartCoroutine(StartRotation(_target.transform.rotation));
    //}

    //private IEnumerator StartRotation(Quaternion quaternion)
    //{
    //    float targetPositionY = quaternion.eulerAngles.y + Random.Range(_minRotation, _maxRotation); 

    //    Vector3 direction = new Vector3(quaternion.x, quaternion.y + targetPositionY, quaternion.z) -
    //        transform.rotation.eulerAngles;

    //    while (transform.rotation.eulerAngles != direction)
    //    {
    //        Quaternion rotation = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speedRotation /** Time.deltaTime*/);
    //        yield return null;
    //    }
    //}
}
