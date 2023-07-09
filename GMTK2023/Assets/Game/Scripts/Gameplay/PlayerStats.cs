using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats:")]
    public float panicLevel;
    public float timeBetween = 3f;

    [SerializeField] GameController gameController;

    [Header("Game Object:")]
    [SerializeField] GameObject kidFlashlight;
    [SerializeField] GameObject kidWakeUpWarning;
    [SerializeField] GameObject kidSleep;
    [SerializeField] GameObject kidFeet1;
    [SerializeField] GameObject kidFeet2;

    public GameObject enemySprite;

    public bool isActive = false;
    public bool animationIsOver = true;
    // Start is called before the first frame update
    void Start()
    {
        panicLevel = 0;
        isActive = false; // TODO: Set this variable to false when ghost is hidden, else set to true
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
        float wait_time = Random.Range(timeBetween, timeBetween+1);
        yield return new WaitForSeconds(wait_time);
        kidWakeUpWarning.SetActive(true);

        //Player wake up timer
        float wait_time2 = Random.Range(timeBetween, timeBetween+1);
        yield return new WaitForSeconds(wait_time);
        RemoveKidSprite();
        kidFlashlight.SetActive(true);

        if (isActive)
        {
            gameController.GameOver();
        }
        else
        {
            float wait_time3 = Random.Range(timeBetween, timeBetween + 1);
            yield return new WaitForSeconds(wait_time);
            RemoveKidSprite();
            kidSleep.SetActive(true);
            animationIsOver = true;
        }
        Debug.Log("Kid is sleeping");
    }

    public void KidWakeUp()
    {
        if (animationIsOver)
        {
            animationIsOver = false;
            StartCoroutine(RandomWaiter());
        }

        Debug.Log("Current panic level =" + panicLevel);
        Debug.Log("Time Between = " + timeBetween);
    }
}
