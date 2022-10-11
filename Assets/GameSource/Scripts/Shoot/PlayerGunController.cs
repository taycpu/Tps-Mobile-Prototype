namespace GameSource.Scripts.Shoot
{
    public class PlayerGunController : GunController
    {
        private bool onShoot;

        public void ChangeGun(GunAttributes attr)
        {
            gunAttributes = attr;
        }

        public new void ShootDirect()
        {
            if (gunAttributes.IsAutomatic)
            {
                onShoot = true;
            }
            else
            {
                Fire();
            }
        }

        private void Update()
        {
            if (onShoot)
            {
                if (!IsOnCooldown())
                {
                    Fire();
                }
            }
        }

        public void Release()
        {
            onShoot = false;
        }
    }
}