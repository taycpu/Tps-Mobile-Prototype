using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShop : MonoBehaviour
{
    [SerializeField] private PlayerGunController gunController;
    [SerializeField] private List<GunAttributes> gunAttributes;

    private int activeGun;


    public void ActivateGun()
    {
        activeGun = 1 - activeGun;
        gunController.ChangeGun(gunAttributes[activeGun]);
    }
}