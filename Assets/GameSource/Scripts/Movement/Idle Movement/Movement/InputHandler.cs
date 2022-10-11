using UnityEngine;

namespace GameSource.Scripts.Movement.Idle_Movement.Movement
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private Vector3 startPos, deltaPos;

        public Vector2 TouchPos => deltaPos;
    
        public void CheckInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
 
            }

            if (Input.GetMouseButton(0))
            {
                deltaPos =Input.mousePosition-startPos;
                deltaPos.x /= Screen.width;
                deltaPos.y /= Screen.height;
            
                startPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                deltaPos = Vector3.zero;
            }
        }
    }
}