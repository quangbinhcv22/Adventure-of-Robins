using SandBox.Scripts;
using TigerForge;
using UnityEngine;

namespace GamePlay.MovementSimulation
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;
        
        private bool _isLanding;
        
        void Start()
        {
            EventManager.StartListening(CharacterInput.StartIdleAnimation, Idle);
            EventManager.StartListening(CharacterInput.StartRunAnimation, Run);
            EventManager.StartListening(CharacterInput.StartJumpAnimation, Jump);
            EventManager.StartListening(CharacterInput.StartAttackAnimation, Attack);
            EventManager.StartListening(CharacterInput.StartDieAnimation, Die);
            EventManager.StartListening(CharacterInput.IsLanding, Landing);
            EventManager.StartListening(CharacterInput.FallDuringRun, FallDuringRun);
        }

        private void Update()
        {
            _isLanding = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }

        private void Idle()
        {
            if (_isLanding)
            {
                animator.SetBool(CharacterInput.IsRunning, false);
            }
        }

        private void Run()
        {
            if (_isLanding)
            {
                animator.SetBool(CharacterInput.IsRunning, true);
            }
        }

        private void Jump()
        {
            animator.SetTrigger(CharacterInput.Jump);
            animator.SetTrigger(CharacterInput.Fall);
        }

        private void Attack()
        {
            animator.SetTrigger(CharacterInput.Attack);
        }
        
        private void Die()
        {
            animator.SetTrigger(CharacterInput.Die);
        }
        
        private void Landing()
        {
            if (_isLanding)
            {
                animator.SetBool(CharacterInput.IsLanding, true);
                animator.ResetTrigger(CharacterInput.Jump);
                animator.ResetTrigger(CharacterInput.Fall);
                
            }
        }

        private void FallDuringRun()
        {
            if (!_isLanding)
            {
                animator.SetBool(CharacterInput.IsLanding, false);
            }
        }
        
    }
}