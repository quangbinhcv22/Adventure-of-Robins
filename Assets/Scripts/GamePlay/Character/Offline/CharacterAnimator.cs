using SandBox.Scripts;
using TigerForge;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;

        private bool _isOnGround;
        void Start()
        {
            EventManager.StartListening("IdleAnimator",IdleAnimator);
            EventManager.StartListening("RunAnimator",RunAnimator);
            EventManager.StartListening("AttackAnimator",AttackAnimator);
            EventManager.StartListening("JumpAnimator",JumpAnimator);
            EventManager.StartListening("FallAfterRunAnimator",FallAfterRunAnimator);
            EventManager.StartListening("DieAnimation",DieAnimator);
        }
    
        void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }
    
        private void IdleAnimator()
        {
            animator.SetBool("Move",false);
            
        }
    
        private void RunAnimator()
        {
            animator.SetBool("Move",true);
        }

        private void AttackAnimator()
        {
            animator.SetTrigger("Attack");
        }
    
        private void JumpAnimator()
        {
            if (_isOnGround)
            {
                animator.SetTrigger("Jump");
                
            }
        }
    
        private void FallAfterRunAnimator()
        {
            if (!_isOnGround)
            {
                animator.SetTrigger("FallAfterRun");
                animator.SetBool("Move",false);
            }
        }

        private void DieAnimator()
        {
            animator.SetTrigger("Die");
        }
    }
}