using UnityEngine;
using UnityEngine.UIElements;

public class EnemyHand : MonoBehaviour
{
    [SerializeField] private PlayerShoting _player;
    [SerializeField] private float _speedRotation = 2f;

    private float _positionRandomY;
    private int _minRotation = 4;
    private int _maxRotation = 12;

    public void SetRandomPositionY()
    {
        _positionRandomY = Random.Range(_minRotation, _maxRotation);
    }

    public void Rotate()
    {       
        float positionY = _player.transform.position.y + _positionRandomY;
        Vector3 direction = new Vector3(_player.transform.position.x, positionY, _player.transform.position.z) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speedRotation * Time.deltaTime);
    }
}
