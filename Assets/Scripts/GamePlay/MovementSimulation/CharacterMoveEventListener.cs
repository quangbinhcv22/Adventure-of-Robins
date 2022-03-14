using Network;
using SandBox.Scripts;
using TigerForge;
using UnityEngine;
using EventName = Network.Events.EventName;

namespace GamePlay.MovementSimulation
{
    public class CharacterMoveEventListener : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Mover mover;
        [SerializeField] private Jumper jumper;

        private void OnEnable()
        {
            EventManager.StartListening(EventName.Server.Character.Move, OnMove);
            EventManager.StartListening(EventName.Server.Character.Jump, OnJump);
        }

        private void OnDisable()
        {
            EventManager.StopListening(EventName.Server.Character.Move, OnMove);
            EventManager.StopListening(EventName.Server.Character.Jump, OnJump);
        }

        private void OnMove()
        {
            var moveResponse = NetworkController.Instance.events.characterMove.Response.data;
            if (character.Info.id != moveResponse.characterId) return;

            mover.Moving(new Vector2(moveResponse.direction, default));

            EventManager.EmitEventData(CharacterInput.StartRunAnimation,moveResponse.characterId);
        }

        private void OnJump()
        {
            var jumpResponse = NetworkController.Instance.events.characterJump.Response.data;
            if (character.Info.id != jumpResponse.characterId) return;

            jumper.Jump();
            EventManager.EmitEventData(CharacterInput.StartJumpAnimation,jumpResponse.characterId);
        }
        
    }
}
