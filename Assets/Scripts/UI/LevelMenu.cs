using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int id)
    {
        string levelName = "Level" + id;
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1;
    }
}
