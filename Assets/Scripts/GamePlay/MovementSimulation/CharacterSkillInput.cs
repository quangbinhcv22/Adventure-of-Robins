using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkillInput : MonoBehaviour
    {
        [SerializeField] private CharacterSkillActivate characterSkillActivate;
        void OnEnable()
        {
            EventManager.StartListening(CharacterInput.Skill1, Skill1);
            EventManager.StartListening(CharacterInput.Skill2, Skill2);
            EventManager.StartListening(CharacterInput.Skill3, Skill3);
        }

        void OnDisable()
        {
            EventManager.StopListening(CharacterInput.Skill1, Skill1);
            EventManager.StopListening(CharacterInput.Skill2, Skill2);
            EventManager.StopListening(CharacterInput.Skill3, Skill3);
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
