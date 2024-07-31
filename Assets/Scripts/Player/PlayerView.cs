using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] protected DamageTextSpawner DamageText;
    [SerializeField] private AudioSource[] _damageSounds;

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
        PlayRandomDamageSound();
        DamageText.Create(transform.position, damage);
    }

    private void PlayRandomDamageSound()
    {
        int index = Random.Range(0, _damageSounds.Length);
        _damageSounds[index].Play();
    }
}
