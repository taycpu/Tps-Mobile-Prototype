using System.Collections.Generic;
using GameSource.Scripts.Shoot;
using UnityEngine;

namespace GameSource.Scripts.Core
{
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
}