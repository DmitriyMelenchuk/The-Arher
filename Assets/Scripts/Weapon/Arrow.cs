using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Transform _startParent;

    public int Damage { get; private set; }

    public bool _isFlight { get; private set; }

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
        if (Time.timeScale == 0)
            gameObject.SetActive(false);

        if (_isFlight == true)          
            Rotate();  
    }

    public void Move(Vector3 velocity, float force)
    {  
        _isFlight = true;
        _rigidbody.isKinematic = false;
        _rigidbody.velocity = velocity * force;
    }

    public void SetToHand(Transform target)
    {
        gameObject.transform.SetParent(target);
        transform.position = target.transform.position;
    }

    public void InitDamage(int damage)
    {
        Damage = damage;
    }

    public void RotateTo(float value)
    {
        if (_isFlight == false)
            transform.localRotation = Quaternion.Euler(0, 0, value);
    }

    private void Rotate()
    {
        gameObject.transform.SetParent(_startParent);
        float angle = Mathf.Atan2(_rigidbody.velocity.y, _rigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
