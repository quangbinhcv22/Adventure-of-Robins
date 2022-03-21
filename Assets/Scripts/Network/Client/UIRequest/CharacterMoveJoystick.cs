using GamePlay.Character;
using Network.Events;
using Photon.Pun;
using SandBox.Scripts;
using TMPro;
using UnityEngine;

namespace Network.Client.UIRequest
{
    public class CharacterMoveJoystick : MonoBehaviour
    {
        [SerializeField] private VariableJoystick joystick;
        [SerializeField] private Character character;

        private void FixedUpdate()
        {
            if (PhotonNetwork.InRoom is false) return;
            if (PhotonNetwork.AuthValues is null) return;
            
            var direction = joystick.Direction;
            //if (direction == Vector2.zero) return;

            var xDirection = (int)new Vector2(direction.x, default).normalized.x;
            var characterId = PhotonNetwork.AuthValues.UserId;
            
            var request = new CharacterMoveRequest { characterId = characterId, direction = xDirection };

            
            NetworkController.Instance.events.characterMove.SendRequest(request);
        }
    }
}