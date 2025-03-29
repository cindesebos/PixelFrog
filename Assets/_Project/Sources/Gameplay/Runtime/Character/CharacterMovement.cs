using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace Sources.Gameplay.Runtime.Character
{
    public class CharacterMovement : MonoBehaviour
    {
        public event Action<float> MoveComputed;

        private float _speed;
        private float _jumpForce;
        private float _checkGroundRadius;
        private LayerMask _groundLayer;

        private float _moveInputX;

        private CharacterData _data;
        private CharacterInput _input;
        private Rigidbody2D _rigidbody2D;

        public void Init(CharacterData data, CharacterInput input, Rigidbody2D rigidbody2D)
        {
            _data = data;
            _input = input;

            _speed = _data.Speed;
            _jumpForce = _data.JumpForce;
            _checkGroundRadius = _data.CheckGroundRadius;
            _groundLayer = _data.GroundLayer;

            _rigidbody2D = rigidbody2D;
        }

        private void Update()
        {
            _moveInputX = ReadMoveInput().x;
            MoveComputed?.Invoke(_moveInputX);

            if(OnJumpReleased() && IsGrounded()) Jump();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move() => _rigidbody2D.linearVelocity = new Vector2(_moveInputX * _speed, _rigidbody2D.linearVelocity.y);

        private void Jump() => _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

        private Vector2 ReadMoveInput() => _input.Movement.Move.ReadValue<Vector2>();

        private bool OnJumpReleased() => _input.Movement.Jump.WasPressedThisFrame();
        
        private bool IsGrounded() => Physics2D.Raycast(transform.position, Vector2.down, _checkGroundRadius, _groundLayer);

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _checkGroundRadius);
        }
    }
}