using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _startParent;

    public bool _isFlight { get; private set; }
    public Creature Creature { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startParent = gameObject.transform.parent;
    }

    private void OnEnable()
    {
        _rigidbody.isKinematic = true;
        _isFlight = false;
    }

    private void Update()
    {
        if (_isFlight == true)
        {
            gameObject.transform.SetParent(_startParent);
            Rotate();
        }   
    }

    public void Move(Vector3 velocity, float force)
    {  
        _isFlight = true;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = velocity * force;
    }

    public void SetToHand(Transform handTransform)
    {
        gameObject.transform.SetParent(handTransform);     
        transform.localRotation = Quaternion.Euler(0,0, handTransform.rotation.z);
    }

    public void InitializeCreature(Creature creature)
    {
        Creature = creature;
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
