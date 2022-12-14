using GameSource.Scripts.Units;
using UnityEngine;

namespace GameSource.Scripts.Shoot
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        private int damage;
        private float currentLiveTime = 3f;

        private bool active;


        public void Initialize(Transform startPoint, GunAttributes gunAttributes)
        {
            transform.position = startPoint.position + startPoint.forward;
            currentLiveTime = gunAttributes.LifeTime;
            damage = gunAttributes.Damage;
            active = true;
            gameObject.SetActive(true);

            rb.AddForce(startPoint.forward * gunAttributes.ShootForce, ForceMode.Impulse);
        }


        public void Dispose()
        {
            active = false;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!active) return;
            currentLiveTime -= Time.deltaTime;
            if (currentLiveTime <= 0)
                Dispose();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Unit>() != null)
            {
                other.gameObject.GetComponent<Unit>().TakeDamage(damage);
            }
        }
    }
}