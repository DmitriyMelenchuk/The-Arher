using UnityEngine;

public class PlayerBow : MonoBehaviour, IWeapon
{
    [SerializeField] private ArrowSpawner _arrowSpawner;
    [SerializeField] private Transform _playerHand;
    [SerializeField] private Vector3 _positionArrow;

    private Arrow _currentArrow;

    private void Update()
    {
        if (_currentArrow != null)
            if (_currentArrow.enabled == true)
                _currentArrow.SetToHand(_playerHand.transform);
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
            _currentArrow.transform.position = _playerHand.transform.position + _positionArrow;
            _currentArrow.InitializeCreature(gameObject.transform.root.GetComponent<Creature>());
        }           
    }
}
