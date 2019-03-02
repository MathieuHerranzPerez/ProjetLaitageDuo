using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver;

    public GameObject gameOverUI;

    void Start()
    {
        IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.GetKeyDown(KeyCode.L)) // TODO delete
            {
                PlayerStats.Lives = 0;
            }


        if (IsGameOver) { }
        else if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        MouseManager.lockMouse = false;                 // unlock the cursor
        IsGameOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;                            // freeze the game
    }
}
