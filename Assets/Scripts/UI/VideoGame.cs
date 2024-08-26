using UnityEngine;
using UnityEngine.UI;

public class VideoGame : MonoBehaviour
{
    [SerializeField] private YandexAds _yandexAds;
    [SerializeField] private Button _button;


    private void OnEnable()
    {
        _button.onClick.AddListener(_yandexAds.OnShowWithReward);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_yandexAds.OnShowWithReward);
    }
}
