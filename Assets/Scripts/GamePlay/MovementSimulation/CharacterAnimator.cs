using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Character character;
        
        public void Idle()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetBool(CharacterInput.IsRunning, false);

                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetBool(CharacterInput.IsRunning, false);

                    break;
                }
            }
        }

        public void Run()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetBool(CharacterInput.IsRunning, true);
                    
                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetBool(CharacterInput.IsRunning, true);
                    
                    break;
                }
            }
        }

        public void Jump()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Jump);
                    animator.SetTrigger(CharacterInput.Fall);
                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Jump);
                    animator.SetTrigger(CharacterInput.Fall);
                    break;
                }
            }
        }

        public void Attack()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Attack);
                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Attack);
                    break;
                }
            }
        }

        public void Die()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetTrigger(CharacterInput.Die);
                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetTrigger(CharacterInput.Die);
                    break;
                }
            }
        }

        public void Landing()
        {
            switch (character.Info.heroID)
            {
                
                case HeroID.Gladiator:
                {
                    animator.SetBool(CharacterInput.IsLanding, true);
                    animator.ResetTrigger(CharacterInput.Jump);
                    animator.ResetTrigger(CharacterInput.Fall);

                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetBool(CharacterInput.IsLanding, true);
                    animator.ResetTrigger(CharacterInput.Jump);
                    animator.ResetTrigger(CharacterInput.Fall);

                    break;
                }
            }
        }

        public void FallDuringRun()
        {
            switch (character.Info.heroID)
            {
                case HeroID.Gladiator:
                {
                    animator.SetBool(CharacterInput.IsLanding, false);

                    break;
                }
                case HeroID.RobinHood:
                {
                    animator.SetBool(CharacterInput.IsLanding, false);

                    break;
                }
            }
        }
    }
}