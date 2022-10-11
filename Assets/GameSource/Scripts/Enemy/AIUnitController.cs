using UnityEngine;

public class AIUnitController : MonoBehaviour
{
    private const int c_soldierEnemyPoolIndex = 1;
    private const int c_patrolEnemyPoolIndex = 2;

    private void Awake()
    {
        GetFromPool(5);
    }

    private void GetFromPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            SoldierEnemy soldierEnemy =
                GenericPoolSingleton.Instance.GetFromPool<SoldierEnemy>(Random.Range(c_soldierEnemyPoolIndex,
                    c_patrolEnemyPoolIndex + 1));
            soldierEnemy.Initialize();
        }
    }
}