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
            var boxingCharacterID = EventManager.GetData(CharacterInput.Skill1);
            var characterID = (string) boxingCharacterID;
            
            characterSkillActivate.ActivateSkill1(characterID);
        }

        private void Skill2()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.Skill2);
            var characterID = (string) boxingCharacterID;
            
            characterSkillActivate.ActivateSkill2(characterID);
        }

        private void Skill3()
        {
            var boxingCharacterID = EventManager.GetData(CharacterInput.Skill3);
            var characterID = (string) boxingCharacterID;
            
            characterSkillActivate.ActivateSkill3(characterID);
        }
    }
}
