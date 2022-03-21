using System;
using GamePlay.Enum;
using TigerForge;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float runSpeed;
        [SerializeField] private Transform model;
        [SerializeField] private new Rigidbody2D rigidbody2D;

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
               Moving(-1);
               EventManager.EmitEvent("RunAnimator");
            }

            if (Input.GetKey(KeyCode.D))
            {
                Moving(1);
                EventManager.EmitEvent("RunAnimator");
            }

            if (!Input.GetKeyUp(KeyCode.A) && !Input.GetKeyUp(KeyCode.D)) return;
            Moving(0);
            EventManager.EmitEvent("IdleAnimator");
        }

        public void Moving(int movingValue)
        {
            var moveVelocity = rigidbody2D.velocity;
            moveVelocity.x = runSpeed * movingValue;

            rigidbody2D.velocity = moveVelocity;
        
            UpdateFacing();
        }
        
        private void UpdateFacing()
        {
            if (rigidbody2D.velocity.x < 0) model.localRotation = Quaternion.Euler(0, 180, 0);
            else if(rigidbody2D.velocity.x > 0) model.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}