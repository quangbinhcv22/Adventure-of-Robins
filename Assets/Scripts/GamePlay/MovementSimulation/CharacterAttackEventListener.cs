using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterAttackEventListener : MonoBehaviour
    {
        [SerializeField] private Character character;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Attack, OnAttack);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Attack, OnAttack);
        }

        private void OnAttack()
        {
            var attackResponse = NetworkController.Instance.events.characterAttack.Response.data;
            if (character.Info.id != attackResponse.characterId) return;

            EventManager.EmitEventData(CharacterInput.StartAttackAnimation,attackResponse.characterId);
        }
    }
}