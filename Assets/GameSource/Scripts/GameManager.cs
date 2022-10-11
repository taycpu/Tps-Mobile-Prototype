using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager
{
    [SerializeField] private List<Manager> managers;

    private void Awake()
    {
        foreach (var manager in managers)
        {
            manager.Initialize();
        }
    }
}