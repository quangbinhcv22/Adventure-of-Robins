using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private float jumpSpeed;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;


        private bool _isOnGround;
        private bool _isDoubleJump;
        private int curentJumpCount;
        private int maxJumpCount = 2;

        private void Start()
        {
            SetMaxCount(curentJumpCount);
        }

        void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
            if (_isOnGround) curentJumpCount = 0;
        }

        private void SetMaxCount(int curentJumpCount)
        {
            curentJumpCount = 0;
        }

        private void SetCanJump(bool canJump)
        {
            _isDoubleJump = canJump;
        }

        private void SetJumpForce(float jumpForce)
        {
            var jumpVelocity = rigidbody2D.velocity;
            jumpVelocity.y = jumpForce;

            rigidbody2D.velocity = jumpVelocity;
        }

        public void Jump()
        {
            if (curentJumpCount >= maxJumpCount) return;
            SetJumpForce(jumpSpeed);
            curentJumpCount++;
        }
    }
}