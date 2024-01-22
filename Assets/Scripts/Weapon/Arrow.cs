using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public event Action<Arrow> ReachedTarget;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Rotate();
    }

    public void Move(Vector3 velocity, float force)
    {
        _rigidbody.velocity = velocity * force;
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
