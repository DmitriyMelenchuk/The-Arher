using UnityEngine;

public class ArrowCollisionHandler : MonoBehaviour
{
    private Arrow arrow;

    private void OnEnable()
    {
        arrow = GetComponent<Arrow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
        {
            if (arrow._isFlight)
            {
                gameObject.transform.position = Vector3.zero;
                gameObject.transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }
                
        }
    }
}
