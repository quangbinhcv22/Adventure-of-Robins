using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterEventListener : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterJump characterJump;
        void Start()
        {
            EventManager.StartListening("CharacterMove",CharacterMoverment);
            EventManager.StartListening("CharacterJump",CharacterJump);
            EventManager.StartListening("CharacterAttack",CharacterAttack);
            EventManager.StartListening("CharacterSkillAttack",CharacterSkillAttack);
            EventManager.StartListening("CharacterGetHit",CharacterGetHit);
            EventManager.StartListening("CharacterHealthChange",CharacterHealthChange);
            EventManager.StartListening("CharacterManaChange",CharacterManaChange);
            EventManager.StartListening("CharacterPowerUp",CharacterPowerUp);
        }

        private void Update()
        {
            CharacterMoverment();
        }

        private void CharacterMoverment()
        {
            var boxingMovermentObject = EventManager.GetData("CharacterMove");
            var movermentData =  (CharacterMovement)boxingMovermentObject;

            characterMove.Moving(movermentData);
        }

        private void CharacterJump()
        {
            var boxingJumpObject = EventManager.GetData("CharacterJump");
            var movermentData =  (CharacterJumping)boxingJumpObject;

            characterJump.Jumping(movermentData);
        }

        private void CharacterAttack()
        {
            
        }

        private void CharacterSkillAttack()
        {
            
        }

        private void CharacterGetHit()
        {
            
        }

        private void CharacterHealthChange()
        {
            
        }

        private void CharacterManaChange()
        {
            
        }

        private void CharacterPowerUp()
        {
            
        }
    }
}
