using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject levelCompletedUI;
    public GameObject gameOverUI;

    public EnemyMovement Enemy;


    public static bool gameOver;
    void Update()
    {
        if(Input.GetKey("space"))
        {
            
        EnemyWalk();

        }else{

        EnemyHide();

        }
    }
 
    // Start is called before the first frame update
    void EnemyWalk()
    {
        Enemy.Walk();
    }
    void EnemyHide()
    {
        Enemy.Hide();
    }
    void Start()
    {
        gameOver = false;
        QualitySettings.vSyncCount = 1;
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
