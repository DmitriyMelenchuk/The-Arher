using UnityEngine;

public class PlayerArrow : ArrowDamage
{
    protected override Creature TryGetCreature(Collision collision)
    {
        collision.gameObject.TryGetComponent(out Enemy enemy);
        return enemy;
    }

}
