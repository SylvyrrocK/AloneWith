using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats:")]
    public float panicLevel;

    public GameController gameController;

    [Header("Game Object:")]
    public GameObject kidFlashlight;
    public GameObject kidWakeUpWarning;
    public GameObject kidSleep;
    public GameObject kidFeet1;
    public GameObject kidFeet2;


    // Start is called before the first frame update
    void Start()
    {
        panicLevel = 0;
    }

    void Update()
    {
       if (panicLevel >= 2)
        {
            gameController.LevelCompleted();
        }
    }

    public void RemoveKidSprite()
    {
        kidWakeUpWarning.SetActive(false);
        kidFlashlight.SetActive(false);
        kidSleep.SetActive(false);
        kidFeet1.SetActive(false);
        kidFeet2.SetActive(false);
    }

    IEnumerator RandomWaiter()
    {
        Debug.Log("Kid woke up");

        //Warning sign timer
        int wait_time = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
        kidWakeUpWarning.SetActive(true); // TODO: UPDATE WAKE UP WARNING TO PROPER SPRITE

        //Player wake up timer
        int wait_time2 = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
        RemoveKidSprite();
        kidFlashlight.SetActive(true);

        //Back to normal state timer
        int wait_time3 = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
        if (panicLevel >= 3) // TODO: UPDATE LOSE CONDITIONS
        {
            gameController.GameOver();
        }
        else
        {
            RemoveKidSprite();
            kidSleep.SetActive(true);
        }
        Debug.Log("Kid woke up");
    }

    public void KidWakeUp()
    {
        StartCoroutine(RandomWaiter());
    }
}
