using UnityEngine;

[RequireComponent(typeof(HealthPotion))]
public class HealthPotionView : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;

    private HealthPotion _healPotion;

    private void Start()
    {
        _healPotion = GetComponent<HealthPotion>();
    }

    private void OnEnable()
    {
        _gameScreen.HealthPotionButtonClick += OnHealthPotionButtonClick;
    }

    private void OnDisable()
    {
        _gameScreen.HealthPotionButtonClick -= OnHealthPotionButtonClick;
    }

    private void OnHealthPotionButtonClick()
    {
        _healPotion.Use();
    }
}
