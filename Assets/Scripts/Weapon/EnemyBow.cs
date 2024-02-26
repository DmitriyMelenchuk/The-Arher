using UnityEngine;

public class EnemyBow : MonoBehaviour, IWeapon
{
    [SerializeField] private EnemyHand _enemyHand;
    [SerializeField] private ArrowSpawner _arrowSpawner;

    private Arrow _currentArrow;

    private void Update()
    {
        if (_currentArrow != null)
            if (_currentArrow.enabled == true)
                _currentArrow.SetToHand(_enemyHand.transform);
    }

    public void Shot(float forceShot)
    {
        _currentArrow.Move(transform.forward, forceShot);
    }

    public void CreateArrow()
    {
        if (Time.timeScale != 0)
        {
            _currentArrow = _arrowSpawner.Create();
            _currentArrow.transform.position = transform.position;
            _currentArrow.InitializeCreature(gameObject.transform.root.GetComponent<Creature>());
        }
    }
}
