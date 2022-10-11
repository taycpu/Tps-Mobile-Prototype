using UnityEngine;

namespace GameSource.Scripts.Misc
{
    public class CameraFollower : MonoBehaviour
    {
        public Camera cam;
        public bool isOn;
        public Vector3 offset;
        [SerializeField] public Transform target;
        [SerializeField] private bool lockX, lockY, lockZ;
        [SerializeField] private float speed;


        public void LateUpdate()
        {
            if (!isOn) return;
            Vector3 tPos = target.position;
            if (lockX)
                tPos.x = 0;
            if (lockY)
                tPos.y = 0;
            if (lockZ)
                tPos.z = 0;

            tPos += offset;
            transform.position = Vector3.MoveTowards(transform.position, tPos, speed);
            transform.LookAt(target);
        }
    }
}