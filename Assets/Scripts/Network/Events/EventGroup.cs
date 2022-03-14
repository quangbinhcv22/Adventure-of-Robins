using UnityEngine;

namespace Network.Events
{
    [CreateAssetMenu(fileName = nameof(EventGroup), menuName = "Server/EventGroup")]
    public class EventGroup : ScriptableObject
    {
        public CharacterAttackEvent characterAttack;
        public CharacterJumpEvent characterJump;
        public CharacterMoveEvent characterMove;
        public CharacterDieEvent characterDie;
        //public CharacterSkillEvent characterSkill;
        public CharacterSkill1Event characterSkill1;
        public CharacterSkill2Event characterSkill2;
        public CharacterSkill3Event characterSkill3;
        //public CharacterSelectEvent characterSelect;
    }
}