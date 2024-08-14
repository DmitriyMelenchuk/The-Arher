using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelMenu : MonoBehaviour
{
    [SerializeField] private int _indexButton;

    private Button _button;
   
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        OpenLevel(_indexButton);
    }

    public void OpenLevel(int id)
    {
        string levelName = "Level" + id;
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1;
    }
}
