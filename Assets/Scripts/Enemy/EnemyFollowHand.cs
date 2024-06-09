using UnityEngine;

public class EnemyFollowHand : MonoBehaviour
{
    [SerializeField] private EnemyHand _enemyHand;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(_enemyHand.transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
