using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float panicLevel;
    public GameController gameController;

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
}
