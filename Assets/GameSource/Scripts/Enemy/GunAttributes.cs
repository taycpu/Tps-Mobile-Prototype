using UnityEngine;

[CreateAssetMenu(menuName = "Attributes/Create GunAttributes", fileName = "GunAttributes", order = 1)]
public class GunAttributes : ScriptableObject
{
    public float Cooldown => cooldown;
    public int Damage => damage;
    public int ShootForce => shootForce;
    public float LifeTime => lifeTime;
    [SerializeField] private float cooldown;
    [SerializeField] private int shootForce;
    [SerializeField] private int damage;
    [SerializeField] private float lifeTime;
}