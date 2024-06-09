using UnityEngine;

[RequireComponent(typeof(Arrow))]
public class ArrowCollisionHandler : MonoBehaviour
{
    private Arrow arrow;

    private void OnEnable()
    {
        arrow = GetComponent<Arrow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (arrow._isFlight)
            {
                gameObject.transform.position = Vector3.zero;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }      
        }
        //if (collision.gameObject.TryGetComponent(out Creature creature))
        //{
        //    if (creature.gameObject.TryGetComponent(out Player player))
        //    {
        //        player.GetComponent()
        //        int damage = arrow.Damage;
        //        player.TakeDamage(damage);
        //    }
        //    if (creature.gameObject.TryGetComponent(out Player enemy))
        //    {
        //        int damage = arrow.Damage;
        //        enemy.TakeDamage(damage);
        //    }
        //}
    }
}
