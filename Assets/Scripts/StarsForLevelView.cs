using UnityEngine;
using UnityEngine.UI;

public class StarsForLevelView : MonoBehaviour
{
    private const int _oneStar = 1;
    private const int _twoStar = 2;
    private const int _threeStar = 3;

    [SerializeField] private GameObject _levelButton;
    [SerializeField] private Sprite _starsImage;

    private void Start()
    {
        Button[] _buttons = _levelButton.transform.GetComponentsInChildren<Button>();

        for (int i = 0; i < _buttons.Length; i++)
        {
            string starsKey = "stars" + (i + _oneStar);
            Image[] images = new Image[_buttons[i].transform.childCount/* - 1*/];

            for (int j = 0; j < images.Length; j++)
                images[j] = _buttons[i].transform.GetChild(j).GetComponent<Image>();

            if (PlayerPrefs.HasKey(starsKey))
            {
                if (PlayerPrefs.GetInt(starsKey) == _oneStar)
                    SetStarsByIndex(images, _oneStar);
                
                else if (PlayerPrefs.GetInt(starsKey) == _twoStar)
                    SetStarsByIndex(images, _twoStar); 

                else if (PlayerPrefs.GetInt(starsKey) == _threeStar)
                    SetStarsByIndex(images, _threeStar);
            }
        }
    }
    
    private void SetStarsByIndex(Image[] images, int index) // ≈сли звезды не закрашиваютс€, изменить индекс
    {
        for (int j = 0; j < index; j++)
        {
            images[j].sprite = _starsImage;
        }
    }
}
