using System.Collections;
using UnityEngine;

public class Enemy : Creature
{
    private EnemyShoting _enemyShoting;
    private float _betweenDie = 2;

    private void Update()
    {
        _enemyShoting.Shoot();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Arrow arrow))
        {
            if (arrow.transform.root.TryGetComponent(out Player player))
            {
                TakeDamage(player.Damage);
            }
        }
    }

    public void Init(EnemyShoting enemyShoting)
    {
        _enemyShoting = enemyShoting;
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
