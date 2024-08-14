using UnityEngine;

[RequireComponent(typeof(Arrow))]
public class ArrowDamage : MonoBehaviour
{
    private Arrow _arrow;

    private void OnEnable()
    {
        _arrow = GetComponent<Arrow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable target))
        {
            target.TakeDamage(_arrow.Damage);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.TakeDamage(_arrow.Damage);
            gameObject.SetActive(false);
        }
    }
}





















