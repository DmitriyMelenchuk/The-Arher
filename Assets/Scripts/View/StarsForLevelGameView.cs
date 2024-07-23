using UnityEngine;
using UnityEngine.UI;

public class StarsForLevelGameView : MonoBehaviour
{
    [SerializeField] private StarsForLevel _starsForLevel;
    [SerializeField] private Sprite _sprite;

    private Image[] _images;

    private void OnEnable()
    {
        _starsForLevel.ChangedCountStars += OnChangedCountStars;
    }

    private void Start()
    {
        _images = GetComponentsInChildren<Image>();
    }

    private void OnDisable()
    {
        _starsForLevel.ChangedCountStars -= OnChangedCountStars;
    }

    private void OnChangedCountStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _images[i].sprite = _sprite;
        }
    }
}
