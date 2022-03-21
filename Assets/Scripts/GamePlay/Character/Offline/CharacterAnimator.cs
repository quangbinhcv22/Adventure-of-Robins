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
        private string currentState;
        private bool _isAttacking;

        void Start()
        {
            EventManager.StartListening("IdleAnimator", IdleAnimator);
            EventManager.StartListening("RunAnimator", RunAnimator);
            EventManager.StartListening("AttackAnimator", AttackAnimator);
            EventManager.StartListening("JumpAnimator", JumpAnimator);
            EventManager.StartListening("DieAnimation", DieAnimator);
        }

        void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }

        private void IdleAnimator()
        {
            animator.SetBool("isRunning", false);
        }

        private void RunAnimator()
        {
            animator.SetBool("isRunning", true);
        }

        private void AttackAnimator()
        {
            animator.SetTrigger("Attack");
        }

        private void JumpAnimator()
        {
            animator.SetTrigger("Jump");
        }

        private void DieAnimator()
        {
            animator.SetTrigger("Die");
        }
    }
}