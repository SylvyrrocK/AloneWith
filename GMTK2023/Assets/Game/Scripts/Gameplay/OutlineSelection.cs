using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Renderer objectRender;
    public Color startingColor;
    public PlayerStats playerStats;
    PanicBar panicBar;
    public float panic = 0f;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        PanicBar.OnPanicValueChanged.AddListener(OnPanicValueChanged);
        objectRender = GetComponent<Renderer>();
        startingColor = Color.white;
    }

    void OnMouseEnter()
    {
        objectRender.material.color = new Color(0f, 0f, 1f, 1f);
    }

    void OnMouseExit()
    {
        objectRender.material.color = startingColor;
    }

    void OnPanicValueChanged(float value)
    {
        panic = value;
        panic += 0.2f;
        playerStats.timeBetween = 1 / (panic * 2);
        playerStats.KidWakeUp();
    }

    //void OnMouseDown()
    //{
    //    panic = panicBar.GetValue("value");
    //    panic += 0.2f;
    //    playerStats.timeBetween = 1/(panic*2);
    //    playerStats.KidWakeUp();
    //}
}

