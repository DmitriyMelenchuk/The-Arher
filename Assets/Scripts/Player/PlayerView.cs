using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] protected DamageTextSpawner DamageText;

    private IDamageable _damageable;

    private void Start()
    {
        _damageable = GetComponent<Player>()._damageable;
        _damageable.TakedDamage += OnTakeDamage;
        _damageable.Died += OnDied;
    }


    private void OnDisable()
    {
        _damageable.TakedDamage -= OnTakeDamage;
        _damageable.Died -= OnDied;
    }

    private void OnDied()
    {
        gameObject.SetActive(false);
    }

    private void OnTakeDamage(int damage)
    {
        DamageText.Create(transform.position, damage);
    }
}
