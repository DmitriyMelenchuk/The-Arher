using System;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;

public class HealthTextView : MonoBehaviour
{
    private const string TextSymbol = "/";

    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _player._damageable.Health;
        SetTextHealth(_maxHealth);
        _player._damageable.ChangedHealth += OnChangeHealth;
    }

    private void OnDisable()
    {
        _player._damageable.ChangedHealth -= OnChangeHealth;
    }

    private void OnChangeHealth(int health)   
    {
        SetTextHealth(health);
    }

    private void SetTextHealth(int health)
    {
        StringBuilder stringBuilder = new StringBuilder(health.ToString());
        stringBuilder.Append(TextSymbol);
        stringBuilder.Append(_maxHealth);
        _text.text = stringBuilder.ToString();
    }
}
