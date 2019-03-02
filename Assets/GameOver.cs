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
        timeText.text = string.Format("{00:00:00.0}", timeSurvived);

        
        PlayerPrefs.GetFloat("bestTime", bestTime);

        if(timeSurvived > bestTime)
        {
            PlayerPrefs.SetFloat("bestTime", timeSurvived);
            bestTimetext.text = string.Format("{00:00:00.0}", timeSurvived);
        }
        else
        {
            bestTimetext.text = string.Format("{00:00:00.0}", bestTime);
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
