using System;
using GameSource.Scripts.Core;
using GameSource.Scripts.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameSource.Scripts.Units
{
    public class AIUnitManager : Manager
    {
        private const int c_soldierEnemyPoolIndex = 1;
        private const int c_patrolEnemyPoolIndex = 2;

        private float lastInstantiateTime;
        private float waitTime = 10;
        public override void Initialize()
        {
            GetFromPool(5);
        }

        private void Update()
        {
            if (Time.time - lastInstantiateTime > waitTime)
            {
                GetFromPool(Random.Range(3, 7));
            }
        }

        private void GetFromPool(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                AIEnemy soldierEnemy =
                    GenericPoolSingleton.Instance.GetFromPool<AIEnemy>(Random.Range(c_soldierEnemyPoolIndex,
                        c_patrolEnemyPoolIndex + 1));
                soldierEnemy.Initialize();
            }

            lastInstantiateTime = Time.time;
            waitTime *= 4f;
        }
    }
}