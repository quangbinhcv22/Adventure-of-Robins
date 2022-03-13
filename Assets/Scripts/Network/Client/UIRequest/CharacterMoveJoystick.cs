using Network.Events;
using TMPro;
using UnityEngine;

namespace Network.Client.UIRequest
{
    public class CharacterMoveJoystick : MonoBehaviour
    {
        [SerializeField] private VariableJoystick joystick;
        [SerializeField] private string characterId => characterIdInput.text;
        [SerializeField] private TMP_InputField characterIdInput;

        private void FixedUpdate()
        {
            var direction = joystick.Direction;
            //if (direction == Vector2.zero) return;

            var xDirection = (int)new Vector2(direction.x, default).normalized.x;
            var request = new CharacterMoveRequest { characterId = characterId, direction = xDirection };

            NetworkController.Instance.events.characterMove.SendRequest(request);
        }
    }
}