using Network.Events;
using UnityEngine;

namespace Network.Client.UIRequest
{
    public class CharacterMoveJoystick : MonoBehaviour
    {
        [SerializeField] private VariableJoystick joystick;

        private void FixedUpdate()
        {
            var direction = joystick.Direction;
            if (direction == Vector2.zero) return;

            var xDirection = (int) new Vector2(direction.x, default).normalized.x;
            NetworkController.Instance.events.characterMove.SendRequest(new CharacterMoveRequest{characterId = "Diaochan", direction =  xDirection});
        }
    }
}