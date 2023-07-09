using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public void NextLevel()
    {
        //TODO add link to next level or level selection screen.
    }

    public void Restart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        //SceneManager.LoadScene("MainMenu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
