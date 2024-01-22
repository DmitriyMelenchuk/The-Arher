using UnityEngine;

[RequireComponent(typeof(Creature))]
public class CreatureView : MonoBehaviour
{
    [SerializeField] protected DamageTextSpawner DamageText;

    private Creature _creature;

    private void Awake()
    {
        _creature = GetComponent<Creature>();
    }

    private void OnEnable()
    {
        _creature.TakedDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        _creature.TakedDamage -= OnTakeDamage;
    }

    private void OnTakeDamage(int damage)
    {
        DamageText.Create(transform.position, damage);
    }
}
