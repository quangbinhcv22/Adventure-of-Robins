using Network.Events;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;


namespace GamePlay.MovementSimulation
{
    public class CharacterAnimatorInput : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Character.Character character;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;


        private string currentState;
        private bool _isOnGround;
        private bool _isAttacking;

        private void Update()
        {
            _isOnGround = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);
        }

        private void Start()
        {
            EventManager.StartListening(CharacterInput.StartIdleAnimation, Idle);
            EventManager.StartListening(CharacterInput.StartRunAnimation, Run);
            EventManager.StartListening(CharacterInput.StartJumpAnimation, Jump);
            EventManager.StartListening(CharacterInput.StartAttackAnimation, Attack);
            // EventManager.StartListening(CharacterInput.StartDieAnimation, Die);
            EventManager.StartListening(CharacterInput.IsLanding, Landing);
            // EventManager.StartListening(CharacterInput.FallDuringRun, FallDuringRun);
        }
        

        private void Idle()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartIdleAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            if (_isOnGround) CharacterAnimatorSwitch("Idle");
        }

        private void Run()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartRunAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;

            CharacterAnimatorSwitch(_isOnGround ? "Run" : "Fall During Run");
        }

        private void Jump()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartJumpAnimation);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;

            CharacterAnimatorSwitch("Jump");
            if (!_isOnGround) CharacterAnimatorSwitch("Fall With Speed");
        }

        private void Attack()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.StartAttackAnimation);
            var characterID = (CharacterAttackResponse) boxingCharacter;
            if (character.Info.id != characterID.characterId) return;

            animator.SetTrigger(CharacterInput.Attack);
            Invoke(nameof(AttackComplete),.8f);
        }

        private void AttackComplete()
        {
            animator.Play("Idle");
            animator.ResetTrigger(CharacterInput.Attack);
        }

        // private void Die()
        // {
        //     var boxingCharacter = EventManager.GetData(CharacterInput.StartDieAnimation);
        //     var characterID = (string) boxingCharacter;
        //     if (character.Info.id != characterID) return;
        //     
        //     characterAnimator.Die();
        // }
        //
        private void Landing()
        {
            var boxingCharacter = EventManager.GetData(CharacterInput.IsLanding);
            var characterID = (string) boxingCharacter;
            if (character.Info.id != characterID) return;
            
            
        }
        //
        // private void FallDuringRun()
        // {
        //     var boxingCharacter = EventManager.GetData(CharacterInput.FallDuringRun);
        //     var characterID = (string) boxingCharacter;
        //     if (character.Info.id != characterID) return;
        //     
        //     characterAnimator.FallDuringRun();
        // }
        private void CharacterAnimatorSwitch(string newState)
        {
            if (currentState == newState) return;

            animator.Play(newState);

            currentState = newState;
        }
    }
}