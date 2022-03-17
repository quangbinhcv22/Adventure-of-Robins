using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;


namespace GamePlay.MovementSimulation
{
    public class CharacterNewListener : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Select, OnNew);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.New, OnNew);
        }

        private void OnNew()
        {
            var newResponse = NetworkController.Instance.events.characterNew.Response.data;
            if (character.Info.id != newResponse.characterId) return;

            
        }
    }
}