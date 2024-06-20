using UnityEngine;

public class HealthPotionView : MonoBehaviour
{
    [SerializeField] private GameScreen _gameScreen;
    [SerializeField] private HealthPotion _healPotion;
   
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
