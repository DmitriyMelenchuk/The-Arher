using UnityEngine;

public class EnemyArrow : ArrowDamage
{
    protected override Creature TryGetCreature(Collision collision)
    {
        collision.gameObject.TryGetComponent(out Player player);
        return player;
    }
}
