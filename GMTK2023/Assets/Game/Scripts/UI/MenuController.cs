using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("FirstLevel");  
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
