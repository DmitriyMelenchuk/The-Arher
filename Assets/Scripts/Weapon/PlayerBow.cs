using UnityEngine;

public class PlayerBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;

    public void Shot(float forceShot)
    {
        if (Time.timeScale != 0)
        {
            Arrow arrow = _arrowSpawner.Create();
            arrow.Move(transform.right, forceShot);
        }
    }
}
