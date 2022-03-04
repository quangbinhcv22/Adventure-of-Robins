using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMoveInput : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterAttack characterAttack;
        [SerializeField] private CharacterJump characterJump;

        void OnEnable()
        {
            EventManager.StartListening("Moving", Moving);
            EventManager.StartListening("Jump", Jump);
        }

        void OnDisable()
        {
            EventManager.StopListening("Moving", Moving);
            EventManager.StopListening("Jump", Jump);
        }

        private void Jump()
        {
            characterJump.Jump();
        }
        private void Moving()
        {
            var boxingMovingValue = EventManager.GetData("Moving");
            var movingValue = (float) boxingMovingValue;

            characterMove.Moving(movingValue);
        }
    }
}