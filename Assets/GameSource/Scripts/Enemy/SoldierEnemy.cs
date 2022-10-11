using UnityEngine;


public class SoldierEnemy : AIEnemy
{
    [SerializeField] private GunController gunController;
    [SerializeField] private FieldOfViewEnemy fieldOfViewEnemy;


    private void Update()
    {
        if (!isAvailable) return;

        if (fieldOfViewEnemy.canSeePlayer)
        {
            if (!agent.isStopped)
                agent.isStopped = true;
            StartShooting();
        }
        else
        {
            Patrol();
        }
    }

    private void StartShooting()
    {
        Vector3 dir = fieldOfViewEnemy.player.position - transform.position;
        dir.y = 0;
        transform.rotation = Quaternion.LookRotation(dir);
        if (!gunController.IsOnCooldown())
            gunController.ShootDirect();
    }
}