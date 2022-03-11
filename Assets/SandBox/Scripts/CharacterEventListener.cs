using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterEventListener : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterJump characterJump;
        [SerializeField] private CharacterSkillAttack characterSkillAttack;
        [SerializeField] private CharacterGetHit characterGetHit;
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
            var jumpData =  (CharacterJumping)boxingJumpObject;

            characterJump.Jumping(jumpData);
        }

        private void CharacterSkillAttack()
        {
            var boxingSkillObject = EventManager.GetData("CharacterSkill1Activate");
            var skillData =  (CharacterSkillAttacking)boxingSkillObject;

            characterSkillAttack.SkillAttacking(skillData);
        }

        private void CharacterGetHit()
        {
            var boxingGetHitObject = EventManager.GetData("CharacterGetHit");
            var getHitData =  (CharacterGetHitting)boxingGetHitObject;

            characterGetHit.GetHitting(getHitData);
        }

        private void CharacterStatChange()
        {
            var boxingStatChangeObject = EventManager.GetData("CharacterStatChange");
            var statChangeData =  (CharacterStatChanging)boxingStatChangeObject;

            characterStatChange.StatChanging(statChangeData);
        }
        
    }
}
