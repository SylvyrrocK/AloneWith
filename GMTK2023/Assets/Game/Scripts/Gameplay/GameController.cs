using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject levelCompletedUI;
    public GameObject gameOverUI;

    public static bool gameOver;
 
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
    }

    public void LevelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
