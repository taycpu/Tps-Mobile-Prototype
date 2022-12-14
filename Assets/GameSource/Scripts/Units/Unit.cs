using GameSource.Scripts.Misc;
using GameSource.Scripts.UI;
using UnityEngine;

namespace GameSource.Scripts.Units
{
    public abstract class Unit : MonoBehaviour
    {
        public bool isAvailable;
        [SerializeField] private HealthUI healthUI;
        [SerializeField] protected UnitAttributes unitAttributes;
        private int health;

        public virtual void Initialize()
        {
            health = unitAttributes.Health;
            isAvailable = true;
        }

        public virtual void TakeDamage(int damage)
        {
            if (!isAvailable) return;
            health -= damage;
            TWEAKS.PlayParticle(4, transform.position);
            healthUI.FillImage((float)health / (float)unitAttributes.Health);
            //Particles,Anims
            if (health <= 0)
                Die();
        }

        protected virtual void Die()
        {
            isAvailable = false;
            TWEAKS.PlayParticle(5, transform.position);
            gameObject.SetActive(false);
        }
    }
}