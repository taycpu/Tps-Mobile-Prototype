using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Manager
{
    [SerializeField] private List<Manager> managers;
    [SerializeField] private PlayerUnit playerUnit;

    public override void Initialize()
    {
        foreach (var manager in managers)
        {
            manager.Initialize();
        }

        playerUnit.Initialize();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}