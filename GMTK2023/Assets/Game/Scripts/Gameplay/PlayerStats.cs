using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats:")]
    public float panicLevel;

    [SerializeField] GameController gameController;

    [Header("Game Object:")]
    [SerializeField] GameObject kidFlashlight;
    [SerializeField] GameObject kidWakeUpWarning;
    [SerializeField] GameObject kidSleep;
    [SerializeField] GameObject kidFeet1;
    [SerializeField] GameObject kidFeet2;

    public GameObject enemySprite;

    public bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        panicLevel = 0;
    }

    void Update()
    {
       if (panicLevel >= 5)
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
        //Warning sign timer
        int wait_time = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
        kidWakeUpWarning.SetActive(true); // TODO: UPDATE WAKE UP WARNING TO PROPER SPRITE

        //Player wake up timer
        int wait_time2 = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
        RemoveKidSprite();
        kidFlashlight.SetActive(true);

        if (isActive) // TODO: UPDATE Game over CONDITIONS
        {
            gameController.GameOver();
        }
        else
        {
            RemoveKidSprite();
            kidSleep.SetActive(true);
        }
        Debug.Log("Kid is sleeping");

        //Back to normal state timer
        int wait_time3 = Random.Range(2, 3);
        yield return new WaitForSeconds(wait_time);
    }

    public void KidWakeUp()
    {
        StartCoroutine(RandomWaiter());
    }
}
