using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkillEventListener : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterSkillActivate characterSkillActivate;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Skill, OnSkill);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Skill, OnSkill);
        }

        private void OnSkill()
        {
            var skillResponse = NetworkController.Instance.events.characterSkill.Response.data;
            if (character.Info.id != skillResponse.characterId) return;

            characterSkillActivate.ActivateSkill(skillResponse.characterId);
        }
    }
}