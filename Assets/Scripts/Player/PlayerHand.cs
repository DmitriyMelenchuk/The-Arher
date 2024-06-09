using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedRotation;

    private void Update()
    {
        transform.position = _target.position;
    }

    public void Rotate(Vector2 mouseScreenPosition)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle * _speedRotation));
    }
}
