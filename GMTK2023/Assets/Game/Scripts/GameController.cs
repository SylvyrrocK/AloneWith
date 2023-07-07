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
        
    }

    // Update is called once per frame
    void Update()
    {
        gameOver = false;
    }

    public void LevelCompleted()
    {
        levelCompletedUI.SetActive(true);
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }
}
