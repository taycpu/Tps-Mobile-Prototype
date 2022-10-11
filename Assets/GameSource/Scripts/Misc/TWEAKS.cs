using GameSource.Scripts.Pool;
using UnityEngine;

namespace GameSource.Scripts.Misc
{
    public static class TWEAKS
    {
        public static void PlayParticle(int index, Vector3 transformPosition)
        {
            var particle = GenericPoolSingleton.Instance.GetFromPool<ParticleSystem>(index);
            particle.transform.position = transformPosition;
            particle.gameObject.SetActive(true);
        }
    }
}