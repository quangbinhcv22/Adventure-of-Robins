using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAnimationActivate : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;
        
        private bool _isLanding;

        private static readonly int IsLanding = Animator.StringToHash("isLanding");
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int IsJumping = Animator.StringToHash("Jump");
        private static readonly int IsAttacking = Animator.StringToHash("Attack");
        private static readonly int Fall = Animator.StringToHash("Fall");

        void Start()
        {
            EventManager.StartListening("StartIdleAnimation", Idle);
            EventManager.StartListening("StartRunAnimation", Run);
            EventManager.StartListening("StartJumpAnimation", Jump);
            EventManager.StartListening("StartAttackAnimation", Attack);
            EventManager.StartListening("Landing", Landing);
            EventManager.StartListening("FallDuringRun", FallDuringRun);
        }

        private void Update()
        {
            _isLanding = IsOnGround();
        }

        private void Idle()
        {
            if (_isLanding)
            {
                animator.SetBool(IsRunning, false);
            }
        }

        private void Run()
        {
            if (_isLanding)
            {
                animator.SetBool(IsRunning, true);
            }
        }

        private void Jump()
        {
            animator.SetTrigger(IsJumping);
            animator.SetTrigger(Fall);
        }

        private void Attack()
        {
            animator.SetTrigger(IsAttacking);
        }

        private void Landing()
        {
            if (_isLanding)
            {
                animator.SetBool(IsLanding, true);
                animator.ResetTrigger(IsJumping);
                animator.ResetTrigger(Fall);
            }
        }

        private void FallDuringRun()
        {
            if (!_isLanding)
            {
                animator.SetBool(IsLanding, false);
            }
        }

        private bool IsOnGround()
            => Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) != null;
    }
}