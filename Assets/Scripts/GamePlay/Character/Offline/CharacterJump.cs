using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private float jumpSpeed;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        private bool _isOnGround;
        private int curentJumpCount;
        private int maxJumpCount = 1;
        void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
            if (_isOnGround) curentJumpCount = 0;
        }

        private void SetJumpForce(float jumpSpeed)
        {
            var jumpVelocity = rigidbody2D.velocity;
            jumpVelocity.y = jumpSpeed;

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