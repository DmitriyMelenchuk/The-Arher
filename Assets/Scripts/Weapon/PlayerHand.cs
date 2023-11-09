using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    public void Rotate(Transform startPosition, Vector2 mouseScreenPosition)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle * _speedRotation));
        Vector3.Lerp(startPosition.position, mouseScreenPosition, Time.deltaTime);
    }
}
