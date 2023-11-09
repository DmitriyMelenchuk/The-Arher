using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private PlayerShoting _player;
    [SerializeField] private ArrowSpawner _arrowSpawner;

    public void Shot(float forceShot)
    {
        Arrow arrow = _arrowSpawner.CreateArrow();
        arrow.Move(transform.forward, forceShot);
    }
}
