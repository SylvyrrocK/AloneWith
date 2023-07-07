using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelection : MonoBehaviour
{
    public Renderer objectRender;
    public Color startingColor;
    public PlayerStats playerStats;

    void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    void Start()
    {
        objectRender = GetComponent<Renderer>();
        startingColor = Color.white;
    }

    void OnMouseEnter()
    {
            objectRender.material.color = new Color(0f, 0f, 1f, 1f);
            Debug.Log("COLOR");
    }

    void OnMouseExit()
    {
            objectRender.material.color = startingColor;
    }

    void OnMouseDown()
    {
        playerStats.panicLevel += 1;
        Debug.Log(playerStats.panicLevel);
    }
}

