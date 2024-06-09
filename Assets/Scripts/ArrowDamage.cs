using UnityEngine;

public abstract class ArrowDamage : MonoBehaviour
{
    [SerializeField] private int _damage;

    public int Damage => _damage;

    protected abstract Creature TryGetCreature(Collision collision);

    private void OnCollisionEnter(Collision collision)
    {
        Creature creature = TryGetCreature(collision);

        if (creature)
        {
            creature.TakeDamage(_damage);
            gameObject.SetActive(false);
        }

        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            obstacle.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}
