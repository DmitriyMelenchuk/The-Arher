using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LanguageView : MonoBehaviour
{
    [SerializeField] private Button _buttonRus;
    [SerializeField] private Button _buttonEng;

    private void OnEnable()
    {
        _buttonRus.onClick.AddListener(OnButtonRusClick);
        _buttonEng.onClick.AddListener(OnButtonEngClick);
    }

    private void Start()
    {
        Close(_buttonEng);
    }

    private void OnDisable()
    {
        _buttonRus.onClick.RemoveListener(OnButtonRusClick);
        _buttonEng.onClick.RemoveListener(OnButtonEngClick);
    }

    private void OnButtonEngClick()
    {
        Close(_buttonEng);
        Open(_buttonRus);
    }

    private void OnButtonRusClick()
    {
        Close(_buttonRus);
        Open(_buttonEng);
    }

    private void Open(Button button)
    {
        button.interactable = true;
    }

    private void Close(Button button)
    {
        button.interactable = false;
    }
}
