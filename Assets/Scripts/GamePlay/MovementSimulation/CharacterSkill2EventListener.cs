using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSkill2EventListener : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Skill2, OnSkill2);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Skill2, OnSkill2);
        }

        private void OnSkill2()
        {
            var skill2Response = NetworkController.Instance.events.characterSkill2.Response.data;
            if (character.Info.id != skill2Response.characterId) return;

            EventManager.EmitEventData(CharacterInput.Skill2,skill2Response.characterId);
        }
    }
}