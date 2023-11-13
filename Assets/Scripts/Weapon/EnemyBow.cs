using UnityEngine;

public class EnemyBow : MonoBehaviour, IWeapon
{
    [SerializeField] private Player _player;
    [SerializeField] private ArrowSpawner _arrowSpawner;

    public void Shot(float forceShot)
    {
        Arrow arrow = _arrowSpawner.CreateArrow();
        arrow.Move(transform.forward, forceShot);
    }
}
