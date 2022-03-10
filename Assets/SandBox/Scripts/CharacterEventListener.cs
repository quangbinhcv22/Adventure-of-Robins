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
            EventManager.StartListening("CharacterSkill1Activate",CharacterSkill1ActivateAttack);
            EventManager.StartListening("CharacterSkill2Activate",CharacterSkill2ActivateAttack);
            EventManager.StartListening("CharacterSkill3Activate",CharacterSkill3ActivateAttack);
            EventManager.StartListening("CharacterGetHit",CharacterGetHit);
            EventManager.StartListening("CharacterStatChange",CharacterStatChange);
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

        private void CharacterSkill1ActivateAttack()
        {
            
        }
        private void CharacterSkill2ActivateAttack()
        {
            
        }private void CharacterSkill3ActivateAttack()
        {
            
        }
        

        private void CharacterGetHit()
        {
            
        }

        private void CharacterStatChange()
        {
            
        }
        
    }
}
