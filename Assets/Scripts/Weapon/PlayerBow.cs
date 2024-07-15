using UnityEngine;

public class PlayerBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;
    [SerializeField] private PlayerDamage _creatureStats;

    private Arrow _currentArrow;


    private void Update()
    {
        if (_currentArrow != null)
            if (_currentArrow.enabled == true)
            {
                _currentArrow.RotateTo(transform.localRotation.z);
            }
    }

    public void Shot(float forceShot)
    {
        if (Time.timeScale != 0)
            _currentArrow.Move(transform.right, forceShot);
    }

    public void CreateArrow()
    {
        if (Time.timeScale != 0)
        {
            _currentArrow = _arrowSpawner.Create();
            _currentArrow.SetToHand(transform);
            _currentArrow.InitDamage(_creatureStats.Damage);
        }           
    }
}
