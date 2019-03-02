using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "Scenes/MainMenu";
    public SceneFader sceneFader;

    [Header("UI")]
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private Text bestTimetext;

    public void Retry()
    {
        Time.timeScale = 1f;                            // unfreeze
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1f;                            // unfreeze
        sceneFader.FadeTo(menuSceneName);
    }
}
