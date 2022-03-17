using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterSelectEventListener : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Select, OnSelect);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Select, OnSelect);
        }

        private void OnSelect()
        {
            var selectResponse = NetworkController.Instance.events.characterSelect.Response.data;
            if (character.Info.id != selectResponse.characterId) return;

            
        }
    }
}