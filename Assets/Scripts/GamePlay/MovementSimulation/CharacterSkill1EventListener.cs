using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkill1EventListener : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterSkillActivate characterSkillActivate;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Skill1, OnSkill1);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Skill1, OnSkill1);
        }

        private void OnSkill1()
        {
            var skill1Response = NetworkController.Instance.events.characterSkill1.Response.data;
            if (character.Info.id != skill1Response.characterId) return;

            characterSkillActivate.ActivateSkill1(skill1Response.characterId);
        }
    }
}