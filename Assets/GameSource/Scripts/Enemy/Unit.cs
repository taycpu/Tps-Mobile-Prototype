using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public bool isAvailable;
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
        TWEAKS.PlayParticle(1, transform.position);
        //Particles,Anims
        if (health <= 0)

            Die();
    }

    protected virtual void Die()
    {
        isAvailable = false;
        TWEAKS.PlayParticle(0, transform.position);
    }
}