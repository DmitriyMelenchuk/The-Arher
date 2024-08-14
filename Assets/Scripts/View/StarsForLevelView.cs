using UnityEngine;
using UnityEngine.UI;

public class StarsForLevelView : MonoBehaviour
{
    private const int OneStar = 1;
    private const int TwoStar = 2;
    private const int ThreeStar = 3;

    [SerializeField] private GameObject _levelButton;
    [SerializeField] private Sprite _starsImage;

    private void Start()
    {
        Button[] buttons = _levelButton.transform.GetComponentsInChildren<Button>();

        for (int i = 0; i < buttons.Length; i++)
        {
            string starsKey = "Level" + (i + OneStar);

            Image[] images = new Image[buttons[i].transform.childCount];

            for (int j = 0; j < images.Length; j++)
                images[j] = buttons[i].transform.GetChild(j).GetComponent<Image>();

            if (PlayerPrefs.HasKey(starsKey))
            {
                if (PlayerPrefs.GetInt(starsKey) == OneStar)
                    SetStarsByIndex(images, OneStar);
                
                else if (PlayerPrefs.GetInt(starsKey) == TwoStar)
                    SetStarsByIndex(images, TwoStar); 

                else if (PlayerPrefs.GetInt(starsKey) == ThreeStar)
                    SetStarsByIndex(images, ThreeStar);
            }
        } 
    }
    
    private void SetStarsByIndex(Image[] images, int index) 
    {
        for (int j = 0; j < index; j++)
        {
            images[j].sprite = _starsImage;
        }
    }
}
