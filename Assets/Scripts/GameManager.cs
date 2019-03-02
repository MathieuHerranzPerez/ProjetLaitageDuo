using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool IsGameOver = false;

    public GameObject gameOverUI;


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
        Debug.Log("Active"); // affD
        Time.timeScale = 0f;                            // freeze the game
    }
}
