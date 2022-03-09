using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterSkillInput : MonoBehaviour
    {
        [SerializeField] private CharacterSkillActivate characterSkillActivate;
        void OnEnable()
        {
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Skill1, Skill1);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Skill2, Skill2);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Skill3, Skill3);
        }

        void OnDisable()
        {
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Skill1, Skill1);
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Skill2, Skill2);
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Skill3, Skill3);
        }

        private void Skill1()
        {
            characterSkillActivate.ActivateSkill1();
        }

        private void Skill2()
        {
            characterSkillActivate.ActivateSkill2();
        }

        private void Skill3()
        {
            characterSkillActivate.ActivateSkill3();
        }
    }
}