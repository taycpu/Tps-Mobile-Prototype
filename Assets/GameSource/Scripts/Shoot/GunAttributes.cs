using UnityEngine;

namespace GameSource.Scripts.Shoot
{
    [CreateAssetMenu(menuName = "Attributes/Create GunAttributes", fileName = "GunAttributes", order = 1)]
    public class GunAttributes : ScriptableObject
    {
        public float Cooldown => cooldown;
        public int Damage => damage;
        public int ShootForce => shootForce;
        public float LifeTime => lifeTime;
        public bool IsAutomatic => isAutomatic;
        [SerializeField] private bool isAutomatic;

        [SerializeField] private float cooldown;
        [SerializeField] private int shootForce;
        [SerializeField] private int damage;
        [SerializeField] private float lifeTime;
    }
}