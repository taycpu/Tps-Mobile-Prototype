namespace IdleMovement
{
    using UnityEngine;

    public abstract class MovementType : MonoBehaviour
    {
        public bool IsMoving => _isMoving;
        public bool CanMove => _canMove;
        [SerializeField] protected LayerMask groundLayer;

        protected bool _isMoving;
        protected bool _canMove;

        public abstract void Initialize();

        public abstract void Stop();
        public abstract void Continue();
        public abstract void SetSpeed(float val);
    }
}