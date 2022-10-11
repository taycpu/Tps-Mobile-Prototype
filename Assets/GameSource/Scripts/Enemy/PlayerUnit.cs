using System;
using IdleMovement;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private GunController gunController;
    [SerializeField] private MovementController movementController;

    private bool isShootingStart;

    public override void Initialize()
    {
        base.Initialize();
        movementController.SetSpeed(unitAttributes.Speed);
    }

    private void Update()
    {
        if (isShootingStart)
        {
            gunController.ShootDirect();
        }
    }

    public void StartShooting()
    {
        isShootingStart = true;
    }

    public void ShootCall()
    {
        if (!gunController.IsOnCooldown())
        {
            gunController.ShootDirect();
        }
    }

    public void StopShooting()
    {
        isShootingStart = false;
    }
}