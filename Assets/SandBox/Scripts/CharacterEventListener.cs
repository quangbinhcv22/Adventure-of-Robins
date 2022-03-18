using System;
using Network.Events;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterEventListener : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterJump characterJump;
       
        
        [SerializeField] private CharacterStatChange characterStatChange;
        void Start()
        {
            EventManager.StartListening("CharacterMove",CharacterMoverment);
            EventManager.StartListening("CharacterJump",CharacterJump);
            EventManager.StartListening("CharacterSkillAttack",CharacterSkillAttack);
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
            var jumpData =  (CharacterJumpEvent)boxingJumpObject;

            characterJump.Jumping(jumpData);
        }

        private void CharacterSkillAttack()
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
