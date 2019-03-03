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


    // intern
    private float bestTime;

    void OnEnable()
    {
        float timeSurvived = PlayerStats.TimeSurvived;
        int nbMin = (int) timeSurvived / 60;
        float restTimeSurvived = timeSurvived % 60;

        timeText.text = string.Format("{0:00}:{1:00}", nbMin, restTimeSurvived);

        
        PlayerPrefs.GetFloat("bestTime", bestTime);

        if (timeSurvived > bestTime)
        {
            PlayerPrefs.SetFloat("bestTime", timeSurvived);

            bestTimetext.text = string.Format("{0:00}:{1:00}", nbMin, restTimeSurvived);
        }
        else
        {
            int nbBestMin = (int) bestTime / 60;
            int restBestTimeSurvived = (int) bestTime % 60;
            bestTimetext.text = string.Format("{0:00}:{1:00}", nbMin, restBestTimeSurvived);
        }
    }

    public void Retry()
    {
        Debug.Log("RETRY"); //affD
        Time.timeScale = 1f;                            // unfreeze
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Debug.Log("MENU"); //affD
        Time.timeScale = 1f;                            // unfreeze
        sceneFader.FadeTo(menuSceneName);
    }
}
