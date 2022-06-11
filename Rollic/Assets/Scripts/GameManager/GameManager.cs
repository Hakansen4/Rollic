﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelGenerator lvlGenerator;
    public PlayerMovement playerMovement;
    
    [Header("Screens")]
    public GameObject startScreen;
    public GameObject failedScreen;
    public GameObject completedScreen;

    bool isStarting;
    private void Awake()
    {
        isStarting = true;
        playerMovement.Deactivate();
    }
    private void Update()
    {
        StartGame();
    }
    public void StartGame()
    {
        if(isStarting)
        {
            if(Input.GetKeyDown(KeyCode.A)  || Input.GetKeyDown(KeyCode.D))
            {
                isStarting = false;
                playerMovement.Activate();
                startScreen.SetActive(false);
            }
        }
    }
    public void Restart()
    {
        lvlGenerator.RestartLevel();
        isStarting = true;
        startScreen.SetActive(true);
    }
    public void NextLevel()
    {
        failedScreen.SetActive(true);
        lvlGenerator.NextLevel();
        isStarting = true;
        startScreen.SetActive(true);
        completedScreen.SetActive(false);
    }
}