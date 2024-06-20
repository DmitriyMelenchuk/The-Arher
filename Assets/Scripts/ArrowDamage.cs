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
    }
}





















//protected abstract Creature GetCreature(Collision collision);

//Creature creature = GetCreature(collision);
//if (creature)
//{
//    creature.TakeDamage(_damage);
//    gameObject.SetActive(false);
//}

//if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
//{
//    obstacle.TakeDamage(_damage);
//    gameObject.SetActive(false);
//}