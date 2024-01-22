using System.Collections;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float _delay;

    private void OnEnable()
    {
        StartCoroutine(DelaySet());
    }

    private IEnumerator DelaySet()
    {
        yield return new WaitForSeconds(_delay);

        gameObject.SetActive(false);
    }
}
