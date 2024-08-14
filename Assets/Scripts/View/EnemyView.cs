using System.Collections;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private const string AnimatorIsDead = "IsDead";

    [SerializeField] private DamageTextSpawner _damageText;
    [SerializeField] private AudioSource _takeDamageSound;
    [SerializeField] private AudioSource[] _diedSound;

    private float _betweenDie = 1f;

    private IDamageable _creature;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _creature = GetComponent<Enemy>()._damageable;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _rigidbody.isKinematic = true;
    }
   
    private void OnEnable()
    {
        _creature.Died += OnDie;
        _creature.TakedDamage += OnTakeDamage;
    }

    private void OnDisable()
    {
        _creature.Died -= OnDie;
        _creature.TakedDamage -= OnTakeDamage;
    }

    private void OnTakeDamage(int damage)
    {
        _damageText.Create(transform.position, damage);
        _takeDamageSound.Play();
    }
    public void OnDie()
    {
        _animator.SetBool(AnimatorIsDead, true);
        PlayRandomDiedSound();
        StartCoroutine(ApplyForced());
    }

    private IEnumerator ApplyForced()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(new Vector3(6f, 6f, 6f) * 20);
        yield return new WaitForSeconds(_betweenDie);
        gameObject.SetActive(false);
    }

    private void PlayRandomDiedSound()
    {
        int index = Random.Range(0, _diedSound.Length);
        _diedSound[index].Play();
    }
}
