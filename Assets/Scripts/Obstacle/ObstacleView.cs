using System;
using System.Collections;
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    [SerializeField] private DamageTextSpawner _textSpawner;

    private Obstacle _obstacle;
    private Collider _collider;
    private MeshRenderer _meshRenderer;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _obstacle = GetComponent<Obstacle>();
        _collider = GetComponent<Collider>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnEnable()
    {
        _obstacle.Died += OnDied;
        _obstacle.TakedDamage += OnTakedDamage;
    }

    private void OnDisable()
    {
        _obstacle.Died -= OnDied;
        _obstacle.TakedDamage -= OnTakedDamage;
    }

    private void OnDied()
    {
        StartCoroutine(DelayDeath());
    }

    private void OnTakedDamage(int damage)
    {
        _textSpawner.Create(transform.position, damage);
        _canvasGroup.alpha = 1;
    }

    private IEnumerator DelayDeath()
    {
        _canvasGroup.alpha = 0;
        _collider.enabled = false;
        _meshRenderer.enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
