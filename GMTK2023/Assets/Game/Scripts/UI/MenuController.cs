using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject creditSceneUI;
    [SerializeField] GameObject menuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menuUI.SetActive(false);
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            menuUI.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Escape");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("FirstLevel");  
    }

    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void Credits()
    {
        creditSceneUI.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
