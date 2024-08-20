using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5f;
    private float currentAngle = 0f;

    public void Rotate(Vector2 mouseScreenPosition)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -50f, 90f);
        currentAngle = Mathf.Lerp(currentAngle, angle, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAngle));
    }
}
