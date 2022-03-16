using System;
using UnityEngine;

namespace SandBox.Scripts
{
    public class 
        MonsterMoving : MonoBehaviour
    {
        [SerializeField] private float runSpeed;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform model;
        [SerializeField] private Transform[] wayPoints;

        bool facingLeft = true;
        private int direction = 1;
        
        private void Update()
        {
            Patrol();
            UpdateFacing();
        }
        
        public  void Move(Vector2 velocity)
        {
            var newVelocity = rigidbody2D.velocity;
            newVelocity.x = velocity.x;
            rigidbody2D.velocity = newVelocity;
        }

        public void Flip()
        {
            facingLeft = !facingLeft;
            var transform1 = model.transform;
            Vector3 scale = transform1.localScale;
            scale.x *= -1;
            transform1.localScale = scale;
        }

        private void UpdateFacing()
        {
            if (rigidbody2D.velocity.x > 0 && facingLeft)
            {
                Flip();
            }
            else if (rigidbody2D.velocity.x < 0 && !facingLeft)
            {
                Flip();
            }
        }
        
        public void Patrol()
        {
            if (this.transform.position.x > wayPoints[0].localPosition.x)
            {
                direction = -1;
            }
            else if (this.transform.position.x < wayPoints[1].localPosition.x)
            {
                direction = 1;
            }
            
            Move(new Vector2(runSpeed * direction, 0));
        }
    }
}
