using UnityEngine;

public class DamagePotionView : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;

    private DamagePotion _damagePotion;

    private void Start()
    {
        _damagePotion = GetComponent<DamagePotion>();
    }

    private void OnEnable()
    {
        _gameScreen.DamagePotionButtonClick += OnDamagePotionButtonClick;
    }

    private void OnDisable()
    {
        _gameScreen.DamagePotionButtonClick -= OnDamagePotionButtonClick;
    }

    private void OnDamagePotionButtonClick()
    {
        _damagePotion.Use();
    }
}
