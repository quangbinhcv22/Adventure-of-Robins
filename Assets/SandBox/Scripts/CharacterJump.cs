using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private float jumpSpeed;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;

        private bool _isOnGround;

        void Update()
        {
            _isOnGround = IsOnGround();
        }

        public void Jump()
        {
            if (_isOnGround)
            {
                var jumpVelocity = rigidbody2D.velocity;
                jumpVelocity.y = jumpSpeed;

                rigidbody2D.velocity = jumpVelocity;
            }
        }

        private bool IsOnGround()
            => Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) != null;
    }
}