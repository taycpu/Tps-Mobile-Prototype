using UnityEngine;

namespace GameSource.Scripts.Units
{
    [CreateAssetMenu(menuName = "Attributes/Create UnitAttributes", fileName = "UnitAttributes", order = 0)]
    public class UnitAttributes : ScriptableObject
    {
        public int Health => health;
        public float Speed => speed;
        [SerializeField] private int health;
        [SerializeField] private float speed;
    }
}