using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMoveInput : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterJump characterJump;
        [SerializeField] private CharacterAttack characterAttack;
        

        void OnEnable()
        {
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Moving, Moving);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Jump, Jump);
            EventManager.StartListening(GameEvent.EventName.CharacterInput.Attack, Attack);
        }

        void OnDisable()
        {
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Moving, Moving);
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Jump, Jump);
            EventManager.StopListening(GameEvent.EventName.CharacterInput.Attack, Attack);
        }

        private void Jump()
        {
            characterJump.Jump();
        }
        private void Moving()
        {
            var boxingMovingValue = EventManager.GetData(GameEvent.EventName.CharacterInput.Moving);
            var movingValue = (float) boxingMovingValue;

            characterMove.Moving(movingValue);
        }

        private void Attack()
        {
            characterAttack.InstantiateArrow();
        }
    }
}