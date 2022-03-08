using System;
using TigerForge;
using UnityEngine;
using static GameEvent.EventName;

namespace SandBox.Scripts
{
    public class CharacterAnimationActivate : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;
        
        private bool _isLanding;

        

        void Start()
        {
            EventManager.StartListening(GameEvent.EventName.CharacterInput.StartIdleAnimation, Idle);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.StartRunAnimation, Run);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.StartJumpAnimation, Jump);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.StartAttackAnimation, Attack);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.IsLanding, Landing);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.FallDuringRun, FallDuringRun);
        }

        private void Update()
        {
            _isLanding = IsOnGround();
            
        }

        private void Idle()
        {
            if (_isLanding)
            {
                animator.SetBool(GameEvent.EventName.CharacterInput.IsRunning, false);
            }
        }

        private void Run()
        {
            if (_isLanding)
            {
                animator.SetBool(GameEvent.EventName.CharacterInput.IsRunning, true);
            }
        }

        private void Jump()
        {
            animator.SetTrigger(GameEvent.EventName.CharacterInput.Jump);
            animator.SetTrigger(GameEvent.EventName.CharacterInput.Fall);
        }

        private void Attack()
        {
            animator.SetTrigger(GameEvent.EventName.CharacterInput.Attack);
        }

        private void Landing()
        {
            if (_isLanding)
            {
                animator.SetBool(GameEvent.EventName.CharacterInput.IsLanding, true);
                animator.ResetTrigger(GameEvent.EventName.CharacterInput.Jump);
                animator.ResetTrigger(GameEvent.EventName.CharacterInput.Fall);
                
            }
        }

        private void FallDuringRun()
        {
            if (!_isLanding)
            {
                animator.SetBool(GameEvent.EventName.CharacterInput.IsLanding, false);
            }
        }

        private bool IsOnGround()
            => Physics2D.OverlapCircle(groundCheck.position, 0.1f, ground) != null;
    }
}