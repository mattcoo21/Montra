using System;
using ProInput.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        public GameObject gfx;


        [Header("Movement")]
        public float movementSpeed;
        public float airMovementSpeed;
        public float maxSpeed;

        [Header("Friction")]
        public float friction;
        public float airFriction;

        [Header("Rotation")]
        public float rotationSensitivity;
        public float rotationBounds;

        [Header("Gravity")]
        public float extraGravity;

        [Header("Ground Detection")]
        public LayerMask whatIsGround;
        public float checkYOffset;
        public float checkRadius;
        public float groundTimer;

        [Header("Jumping")]
        public float jumpForce;

        [Header("Data")]
        public Camera playerCamera;
        public Transform playerCameraHolder;
        public Rigidbody playerRigidBody;

        private InputObject _forwardsInput;
        private InputObject _backwardsInput;
        private InputObject _leftInput;
        private InputObject _rightInput;
        private InputObject _jumpInput;

        private float _xRotation;
        private float _yRotation;
        private float _grounded;
        private bool _realGrounded;

        Vector3 velocity;


        private void Start()
        {
            _forwardsInput = new InputObject("Forwards", Key.W);
            _backwardsInput = new InputObject("Backwards", Key.S);
            _leftInput = new InputObject("Left", Key.A);
            _rightInput = new InputObject("Right", Key.D);
            _jumpInput = new InputObject("Jump", Key.Space);
        }

        private void FixedUpdate()
        {
            GroundCheck();
            ApplyMovement();
            ApplyFriction();
            ApplyGravity();
        }

        private void Update()
        {
            Rotation();
            Jumping();
            Crouching();
            Walking();
        }

        private void Walking()
        {
            maxSpeed = 18f;
        }

        private void Crouching()
        {
            if (Input.GetKey(KeyCode.C) && _realGrounded)
            {
                StartCrouch();
            }
            else
            {
                StopCrouch();
            }
        }

        private void StartCrouch()
        {
            gfx.transform.localScale = new Vector3(1f, 0.6f, 1f);

        }

        private void StopCrouch()
        {
            gfx.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        private void GroundCheck()
        {
            _grounded -= Time.deltaTime;
            var colliderList = new Collider[100];
            var size = Physics.OverlapSphereNonAlloc(transform.position + new Vector3(0, checkYOffset, 0), checkRadius, colliderList, whatIsGround);
            _realGrounded = size > 0;
            if (_realGrounded)
                _grounded = groundTimer;
        }

        private void ApplyMovement()
        {
            var axis = new Vector2(
                (_leftInput.IsPressed ? -1 : 0) + (_rightInput.IsPressed ? 1 : 0),
                (_backwardsInput.IsPressed ? -1 : 0) + (_forwardsInput.IsPressed ? 1 : 0)
            ).normalized;

            var speed = _realGrounded ? movementSpeed : airMovementSpeed;
            var vertical = axis.y * speed * Time.fixedDeltaTime * transform.forward;
            var horizontal = axis.x * speed * Time.fixedDeltaTime * transform.right;

            if (CanApplyForce(vertical, axis))
                playerRigidBody.velocity += vertical;

            if (CanApplyForce(horizontal, axis))
                playerRigidBody.velocity += horizontal;
        }

        private void ApplyFriction()
        {
            var vel = playerRigidBody.velocity;
            var target = _realGrounded ? friction : airFriction;
            vel.x = Mathf.Lerp(vel.x, 0f, target * Time.fixedDeltaTime);
            vel.z = Mathf.Lerp(vel.z, 0f, target * Time.fixedDeltaTime);
            playerRigidBody.velocity = vel;
        }

        private void Rotation()
        {
            Cursor.lockState = CursorLockMode.Locked;
            var mouseDelta = Mouse.current.delta.ReadValue();

            _xRotation -= mouseDelta.y * rotationSensitivity;
            _xRotation = Mathf.Clamp(_xRotation, -rotationBounds, rotationBounds);
            _yRotation += mouseDelta.x * rotationSensitivity;

            transform.rotation = Quaternion.Euler(0, _yRotation, 0);
            playerCameraHolder.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        }

        private void ApplyGravity()
        {
            var vel = playerRigidBody.velocity;
            vel.y -= Mathf.Abs(vel.y) * Time.fixedDeltaTime * extraGravity;
            playerRigidBody.velocity = vel;
        }

        private void Jumping()
        {
            if (!(_grounded >= 0) || !_jumpInput.IsDown) return;
            var vel = playerRigidBody.velocity;
            vel.y = jumpForce;
            playerRigidBody.velocity = vel;
        }

        private bool CanApplyForce(Vector3 target, Vector2 axis)
        {
            var targetC = Get2DVec(target).normalized;
            var velocityC = Get2DVec(playerRigidBody.velocity).normalized;
            var dotProduct = Vector2.Dot(velocityC, targetC);
            return dotProduct <= 0 || dotProduct * Get2DVec(playerRigidBody.velocity).magnitude < maxSpeed * GetAxisForce(axis);
        }

        private static float GetAxisForce(Vector2 axis)
        {
            return (int)axis.x != 0 ? Mathf.Abs(axis.x) : Mathf.Abs(axis.y);
        }

        private static Vector2 Get2DVec(Vector3 vec)
        {
            return new Vector2(vec.x, vec.z);
        }
    }
}
