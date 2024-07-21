//using System;
//using System.Collections;
//using UnityEngine;

//[RequireComponent(typeof(Creature))]
//public class CreatureView : MonoBehaviour
//{
//    [SerializeField] protected DamageTextSpawner DamageText;
//    private float _betweenDie = 2;

//    private IDamageable _creature;
//    private Rigidbody _rigidbody;

//    private void Awake()
//    {
//        _creature = GetComponent<Enemy>()._damageable;
//        _rigidbody = GetComponent<Rigidbody>();
//        _rigidbody.isKinematic = true;
//    }
   
//    private void OnEnable()
//    {
//        _creature.Died += OnDie;
//        _creature.TakedDamage += OnTakeDamage;
//    }

//    private void OnDisable()
//    {
//        _creature.Died -= OnDie;
//        _creature.TakedDamage -= OnTakeDamage;
//    }

//    private void OnTakeDamage(int damage)
//    {
//        DamageText.Create(transform.position, damage);
//    }
//    public void OnDie()
//    {
//        StartCoroutine(ApplyForced());
//    }

//    private IEnumerator ApplyForced()
//    {
//        _rigidbody.isKinematic = false;
//        _rigidbody.AddForce(new Vector3(2f, 6f, 6f) * 20);
//        yield return new WaitForSeconds(_betweenDie);
//        gameObject.SetActive(false);
//    }
//}
