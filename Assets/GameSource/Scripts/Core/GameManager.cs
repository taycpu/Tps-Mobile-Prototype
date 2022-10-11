using System.Collections.Generic;
using GameSource.Scripts.Units;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSource.Scripts.Core
{
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
}