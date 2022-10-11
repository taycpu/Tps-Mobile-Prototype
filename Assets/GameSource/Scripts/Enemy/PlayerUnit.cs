using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private GunController gunController;


    public void ShootCall()
    {
        if (!gunController.IsOnCooldown())
        {
            gunController.ShootDirect();
        }
    }
}