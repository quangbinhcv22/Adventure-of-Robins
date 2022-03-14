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

        private void Update()
        {
            _isLanding = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }

        public void Idle(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsRunning, false);
                    }
                    break;
                }
                case CharacterID.RobinHood:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsRunning, false);
                    }
                    break;
                }
            }
            
        }

        public void Run(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsRunning, true);
                    }

                    break;
                }
                case CharacterID.RobinHood:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsRunning, true);
                    }

                    break;
                }
            }
        }

        public void Jump(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Jump);
                    animator.SetTrigger(CharacterInput.Fall);
                    break;
                }
                case CharacterID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Jump);
                    animator.SetTrigger(CharacterInput.Fall);
                    break;
                }
            }
        }

        public void Attack(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Attack);
                    break;
                }
                case CharacterID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Attack);
                    break;
                }
            }
        }

        public void Die(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Die);
                    break;
                }
                case CharacterID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Die);
                    break;
                }
            }
            
        }

        public void Landing(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsLanding, true);
                        animator.ResetTrigger(CharacterInput.Jump);
                        animator.ResetTrigger(CharacterInput.Fall);
                    }
                    break;
                }
                case CharacterID.RobinHood:
                {
                    if (_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsLanding, true);
                        animator.ResetTrigger(CharacterInput.Jump);
                        animator.ResetTrigger(CharacterInput.Fall);
                    }
                    break;
                }
            }
            
        }

        public void FallDuringRun(string characterID)
        {
            switch (characterID)
            {
                case CharacterID.Gladiator:
                {
                    if (!_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsLanding, false);
                    }
                    break;
                }
                case CharacterID.RobinHood:
                {
                    if (!_isLanding)
                    {
                        animator.SetBool(CharacterInput.IsLanding, false);
                    }
                    break;
                }
            }
            
        }
    }
}