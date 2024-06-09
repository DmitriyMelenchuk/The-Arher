using System.Collections;
using UnityEngine;

public class Enemy : Creature
{    
    private float _betweenDie = 2;

    private void Awake()
    {
        Rigidbody.isKinematic = true;
    }

    protected override void OnDie()
    {
        StartCoroutine(ApplyForced());
    }

    private IEnumerator ApplyForced()
    {
        Rigidbody.isKinematic = false;
        Rigidbody.AddForce(new Vector3(2f,6f,6f) * 20);
        yield return new WaitForSeconds(_betweenDie);
        gameObject.SetActive(false);
    }
}
