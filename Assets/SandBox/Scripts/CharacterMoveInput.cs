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
            EventManager.StartListening("Attack", Attack);
            EventManager.StartListening("Jump", Jump);
        }

        void OnDisable()
        {
            EventManager.StopListening("Moving", Moving);
            EventManager.StopListening("Attack", Attack);
            EventManager.StopListening("Jump", Jump);
        }

        private void Jump()
        {
            characterJump.Jump();
        }
        private void Attack()
        {
            var attackIEnumerator = characterAttack.Attacking();
            StartCoroutine(attackIEnumerator);
        }
        private void Moving()
        {
            var boxingMovingValue = EventManager.GetData("Moving");
            var movingValue = (float) boxingMovingValue;

            characterMove.Moving(movingValue);
        }
    }
}