using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkill3EventListener : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private CharacterSkillActivate characterSkillActivate;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Skill3, OnSkill3);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Skill3, OnSkill3);
        }

        private void OnSkill3()
        {
            var skill3Response = NetworkController.Instance.events.characterSkill3.Response.data;
            if (character.Info.id != skill3Response.characterId) return;

            characterSkillActivate.ActivateSkill3();
        }
    }
}