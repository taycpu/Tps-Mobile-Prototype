namespace IdleMovement
{
    using System;
    using UnityEngine;

    public enum MovementMethod
    {
        TransformBased,
        RigidbodyBased
    }

    public class FreeroamMovement : MovementType
    {
        private Vector2 input;
        [SerializeField] private float speed = 5;
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform rayPos;
        [SerializeField] private JoystickScript joystick;

        [SerializeField] private MovementMethod method;
        [SerializeField] private bool isRelativeMove;
        [SerializeField] private Transform relativeObject;

        private void Update()
        {
            if (method == MovementMethod.TransformBased)
                MoveUpdate(joystick.Output);
        }

        private void FixedUpdate()
        {
            if (method == MovementMethod.RigidbodyBased)
                MoveUpdate(joystick.Output);
        }

        public void MoveUpdate(Vector2 input)
        {
            if (Physics.Raycast(rayPos.position, Vector3.down, Mathf.Infinity, groundLayer))
            {
                if (method == MovementMethod.TransformBased)
                    MoveTransform(transform, input);
                else if (method == MovementMethod.RigidbodyBased)
                    MoveRigidbody(rb, input);
            }
            else
            {
                var angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
                var diff = Mathf.Abs(angle - ToRealAngle(transform.eulerAngles.y));

                if (diff > 100)
                {
                    if (method == MovementMethod.TransformBased)
                        MoveTransform(transform, input);
                    else if (method == MovementMethod.RigidbodyBased)
                        MoveRigidbody(rb, input);
                }
                else
                {
                    this.input = Vector3.zero;
                }
            }
        }


        public void MoveTransform(Transform transform, Vector2 input)
        {
            this.input = input;
            var direction = new Vector3(input.x, 0, input.y);
            var canDirection = relativeObject.transform.rotation * direction;
            var targetDirection = Vector3.zero;

            var angle = 0f;
            if (isRelativeMove)
            {
                targetDirection = new Vector3(canDirection.x, 0, canDirection.z).normalized;

                angle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            }
            else
            {
                targetDirection = transform.forward;
                angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            }

            if (input.x != 0 && input.y != 0)
            {
                transform.position =
                    (Vector3.MoveTowards(transform.position, (transform.position + targetDirection),
                        (speed * Time.deltaTime)));
                transform.rotation = (Quaternion.Euler(0, angle, 0));
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }
        }

        public void MoveRigidbody(Rigidbody rigidbody, Vector2 input)
        {
            this.input = input;
            var direction = new Vector3(input.x, 0, input.y);
            var canDirection = relativeObject.transform.rotation * direction;
            var targetDirection = Vector3.zero;

            var angle = 0f;
            if (isRelativeMove)
            {
                targetDirection = new Vector3(canDirection.x, 0, canDirection.z).normalized;

                angle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
            }
            else
            {
                targetDirection = transform.forward;
                angle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            }

            if (input.x != 0 && input.y != 0)
            {
                rigidbody.MovePosition(
                    (Vector3.MoveTowards(rigidbody.position, (rigidbody.position + targetDirection),
                        (speed * Time.deltaTime))));
                rigidbody.rotation = (Quaternion.Euler(0, angle, 0));
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }
        }


        public static float ToRealAngle(float axis)
        {
            float tiltX = 0.0f;

            if (axis < 180f)
            {
                tiltX = axis;
            }
            else
            {
                tiltX = -(360 - axis);
            }

            return tiltX;
        }

        public override void Initialize()
        {
            _canMove = true;
        }

        public override void Stop()
        {
            _canMove = false;
            _isMoving = false;
        }

        public override void Continue()
        {
            _canMove = true;
        }

        public override void SetSpeed(float val)
        {
            speed = val;
        }

        private void Reset()
        {
            if (FindObjectOfType<JoystickScript>() != null)
                joystick = FindObjectOfType<JoystickScript>();
            relativeObject = Camera.main.transform;
            if (rb == null)
            {
                if (gameObject.GetComponent<Rigidbody>() != null)
                {
                    rb = GetComponent<Rigidbody>();
                    rb.interpolation = RigidbodyInterpolation.Extrapolate;
                    rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
                }
            }
        }
    }
}