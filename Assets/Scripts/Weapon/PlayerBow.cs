using UnityEngine;

public class PlayerBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;

    public void Shot(float forceShot)
    {
        Arrow arrow = _arrowSpawner.CreateArrow();
        arrow.Move(transform.right, forceShot);
    }
}
