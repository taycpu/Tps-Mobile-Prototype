using UnityEngine;

public class AIUnitManager : Manager
{
    private const int c_soldierEnemyPoolIndex = 1;
    private const int c_patrolEnemyPoolIndex = 2;

    public override void Initialize()
    {
        GetFromPool(5);
    }


    private void GetFromPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AIEnemy soldierEnemy =
                GenericPoolSingleton.Instance.GetFromPool<AIEnemy>(Random.Range(c_soldierEnemyPoolIndex,
                    c_patrolEnemyPoolIndex+1));
            soldierEnemy.Initialize();
        }
    }
}