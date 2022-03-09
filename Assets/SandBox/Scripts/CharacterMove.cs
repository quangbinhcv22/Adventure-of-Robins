using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float runSpeed;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform model;

        private bool _isMoving = true;
        private void UpdateFacing()
        {
            if (rigidbody2D.velocity.x < 0) model.localRotation = Quaternion.Euler(0, 180, 0);
            else if(rigidbody2D.velocity.x > 0) model.localRotation = Quaternion.Euler(0, 0, 0);
        }

        public void SetCanMove(bool canMove)
        {
            _isMoving = canMove;
        }

        public void SetSpeed(float speed)
        {
            var movingVelocity = rigidbody2D.velocity;
            movingVelocity.x = speed * runSpeed;
            
            rigidbody2D.velocity = movingVelocity;
        }
        public void Moving(Vector2 direction)
        {
            if (_isMoving)
            {
                SetSpeed(direction.x);
            }
            UpdateFacing();
        }
    }
}
