using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DamagePotionView))]
public class DamagePotionView : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private TMP_Text _potionCount;

    private IPotion _damagePotion;

    private void Awake()
    {
        _damagePotion = GetComponent<DamagePotion>();
    }

    private void OnEnable()
    {
        _gameScreen.DamagePotionButtonClick += OnDamagePotionButtonClick;
        _damagePotion.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _gameScreen.DamagePotionButtonClick -= OnDamagePotionButtonClick;
        _damagePotion.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _potionCount.text = value.ToString();
    }

    private void OnDamagePotionButtonClick()
    {
        _damagePotion.Use();
    }
}
