using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterDieEventListener : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Die, OnDie);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Attack, OnDie);
        }

        private void OnDie()
        {
            var attackResponse = NetworkController.Instance.events.characterAttack.Response.data;
            if (character.Info.id != attackResponse.characterId) return;

            EventManager.EmitEvent(CharacterInput.StartDieAnimation);
        }
    }
}