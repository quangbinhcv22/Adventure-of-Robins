using SandBox.Scripts;
using TigerForge;
using UnityEngine;


namespace GamePlay.MovementSimulation
{
    public class CharacterAnimatorInput : MonoBehaviour
    {
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private Character character;

        void OnEnable()
        {
            EventManager.StartListening(CharacterInput.StartIdleAnimation, Idle);
            EventManager.StartListening(CharacterInput.StartRunAnimation, Run);
            EventManager.StartListening(CharacterInput.StartJumpAnimation, Jump);
            EventManager.StartListening(CharacterInput.StartAttackAnimation, Attack);
            EventManager.StartListening(CharacterInput.StartDieAnimation, Die);
            EventManager.StartListening(CharacterInput.IsLanding, Landing);
            EventManager.StartListening(CharacterInput.FallDuringRun, FallDuringRun);
        }

        void OnDisable()
        {
            EventManager.StopListening(CharacterInput.StartIdleAnimation, Idle);
            EventManager.StopListening(CharacterInput.StartRunAnimation, Run);
            EventManager.StopListening(CharacterInput.StartJumpAnimation, Jump);
            EventManager.StopListening(CharacterInput.StartAttackAnimation, Attack);
            EventManager.StopListening(CharacterInput.StartDieAnimation, Die);
            EventManager.StopListening(CharacterInput.IsLanding, Landing);
            EventManager.StopListening(CharacterInput.FallDuringRun, FallDuringRun);
        }

        private void Idle()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            //characterAnimator.Die();
        }

        private void Run()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartRunAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            characterAnimator.Run();
        }

        private void Jump()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartJumpAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;

            //characterAnimator.Jump(heroID);
        }

        private void Attack()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;

            //characterAnimator.Attack();
        }

        private void Die()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            //characterAnimator.Die(characterID);
        }

        private void Landing()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            //characterAnimator.Landing(characterID);
        }

        private void FallDuringRun()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            //characterAnimator.FallDuringRun(characterID);
        }
    }
}