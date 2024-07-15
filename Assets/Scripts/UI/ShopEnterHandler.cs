using UnityEngine;
using UnityEngine.EventSystems;

public class ShopEnterHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        Close();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Open();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Close();
    }

    private void Open()
    {
        _gameObject.SetActive(true);
    }

    private void Close()
    {
        _gameObject.SetActive(false);
    }
}
