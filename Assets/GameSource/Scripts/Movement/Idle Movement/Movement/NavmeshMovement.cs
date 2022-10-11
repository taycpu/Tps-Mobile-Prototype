using UnityEngine;
using UnityEngine.AI;

namespace GameSource.Scripts.Movement.Idle_Movement.Movement
{
    public class NavmeshMovement : MovementType
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Camera cam;


        private void Update()
        {
            if (!CanMove) return;
            CheckPosition();
            _isMoving = !agent.isStopped;
        }

        public void CheckPosition()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
                    NavmeshSetDestination(hit.point);
            }
        }

        public void NavmeshSetDestination(Vector3 pos)
        {
            print(pos);
            agent.SetDestination(pos);
        }


        public override void Initialize()
        {
            _canMove = true;
        }

        public override void Stop()
        {
            agent.isStopped = true;
        }

        public override void Continue()
        {
            agent.isStopped = false;
        }

        public override void SetSpeed(float val)
        {
            agent.speed = val;
        }
    }
}