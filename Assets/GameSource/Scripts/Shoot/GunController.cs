using GameSource.Scripts.Misc;
using GameSource.Scripts.Pool;
using UnityEngine;

namespace GameSource.Scripts.Shoot
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private Transform gunPos;
        [SerializeField] protected GunAttributes gunAttributes;

        private float lastShootTime;


        public void ShootDirect()
        {
            Fire();
        }

        public bool IsOnCooldown()
        {
            return Time.time - lastShootTime < gunAttributes.Cooldown;
        }

        protected void Fire()
        {
            lastShootTime = Time.time;
            Bullet bullet = GenericPoolSingleton.Instance.GetFromPool<Bullet>(0);
            TWEAKS.PlayParticle(3, gunPos.position + gunPos.forward);
            bullet.transform.rotation = gunPos.transform.rotation;
            bullet.Initialize(gunPos, gunAttributes);
        }
    }
}