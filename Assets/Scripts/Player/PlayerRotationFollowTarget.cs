using UnityEngine;

public class PlayerRotationFollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    
    public void Update()
    {
        transform.rotation = Quaternion.Euler(-_hand.transform.rotation.z * 70f, 90f, 0f);
    }
}
