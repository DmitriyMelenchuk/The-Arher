using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private ArrowSpawner _arrowSpawner;
    [SerializeField] private float _speedRotation;

    public void Rotate(Transform startPosition, Vector2 mouseScreenPosition)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle * _speedRotation));
        Vector3.Lerp(startPosition.position, mouseScreenPosition, Time.deltaTime);
    }

    public void Shot(float forceShot)
    {
        Arrow arrow = _arrowSpawner.CreateArrow();
        arrow.Move(transform.right, forceShot);
    }
}
