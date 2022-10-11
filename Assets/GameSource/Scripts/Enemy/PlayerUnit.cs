using System;
using IdleMovement;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private PlayerGunController gunController;
    [SerializeField] private MovementController movementController;

    private bool isShootingStart;

    public override void Initialize()
    {
        base.Initialize();
        movementController.SetSpeed(unitAttributes.Speed);
    }


    public void ShootCall()
    {
        if (!gunController.IsOnCooldown())
        {
            gunController.ShootDirect();
        }
    }

    public void ShootRelease()
    {
        gunController.Release();
    }
}