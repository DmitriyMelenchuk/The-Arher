using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(HealthPotion))]
public class HealthPotionView : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private TMP_Text _potionCount;

    private IPotion _healPotion;

    private void Awake()
    {
        _healPotion = GetComponent<HealthPotion>();
    }

    private void OnEnable()
    {
        _gameScreen.HealthPotionButtonClick += OnHealthPotionButtonClick;
        _healPotion.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _gameScreen.HealthPotionButtonClick -= OnHealthPotionButtonClick;
        _healPotion.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _potionCount.text = value.ToString();
    }

    private void OnHealthPotionButtonClick()
    {
        _healPotion.Use();
    }
}
