using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public string mainSceneName = "Scenes/MainScene";
    public SceneFader sceneFader;

    public GameObject tutoGameObject;
    public GameObject creditsGameObject;

    public void Play()
    {
        sceneFader.FadeTo(mainSceneName);
    }

    public void DisplayTuto()
    {
        tutoGameObject.SetActive(true);
    }

    public void DisplayCredits()
    {
        creditsGameObject.SetActive(true);
    }
}
