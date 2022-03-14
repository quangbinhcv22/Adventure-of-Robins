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
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;
            
            characterAnimator.Die(characterID);
        }

        private void Run()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;

            characterAnimator.Run(characterID);
        }

        private void Jump()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartJumpAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;

            characterAnimator.Jump(characterID);
        }

        private void Attack()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;

            characterAnimator.Attack(characterID);
        }

        private void Die()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;
            
            characterAnimator.Die(characterID);
        }

        private void Landing()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;
            
            characterAnimator.Landing(characterID);
        }

        private void FallDuringRun()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (string) boxingCharacterID;
            if (character.Info.id != characterID) return;
            
            characterAnimator.FallDuringRun(characterID);
        }
    }
}