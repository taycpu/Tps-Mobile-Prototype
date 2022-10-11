using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private Transform gunPos;
    [SerializeField] private GunAttributes gunAttributes;

    private float lastShootTime;


    public void ShootDirect()
    {
        Fire();
        lastShootTime = Time.time;
    }

    public bool IsOnCooldown()
    {
        return Time.time - lastShootTime < gunAttributes.Cooldown;
    }

    private void Fire()
    {
        Bullet bullet = GenericPoolSingleton.Instance.GetFromPool<Bullet>(0);
        // TWEAKS.PlayParticle(3, gunPos.position + gunPos.forward);
        bullet.transform.rotation = gunPos.transform.rotation;
        bullet.Initialize(gunPos, gunAttributes);
    }
}