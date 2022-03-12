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
        private int jumpCount;

        void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }

        public void SetMaxCount(int maxCount)
        {
            jumpCount = maxCount;
        }

        public void SetCanJump(bool canJump)
        {
            _isDoubleJump = canJump;
        }

        public void SetJumpForce(float jumpForce)
        {
            var jumpVelocity = rigidbody2D.velocity;
            jumpVelocity.y = jumpForce;

            rigidbody2D.velocity = jumpVelocity;
            
            
        }
        public void Jump()
        {
            if (_isOnGround)
            {
                SetMaxCount(jumpCount);
                SetJumpForce(jumpSpeed);
                jumpCount--;
                _isOnGround = false;
                SetCanJump(_isDoubleJump);
                
                if (_isDoubleJump && jumpCount > 0)
                {
                    SetJumpForce(jumpSpeed);
                    
                }
            }
        }
        
    }
}