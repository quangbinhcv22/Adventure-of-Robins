using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMoveInput : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        [SerializeField] private Jumper jumper;


        void OnEnable()
        {
            EventManager.StartListening(CharacterInput.Moving, Moving);
            EventManager.StartListening(CharacterInput.Jump, Jump);
        }

        void OnDisable()
        {
            EventManager.StopListening(CharacterInput.Moving, Moving);
            EventManager.StopListening(CharacterInput.Jump, Jump);
        }

        private void Jump()
        {
            jumper.Jump();
        }

        private void Moving()
        {
            var boxingMovingValue = EventManager.GetData(CharacterInput.Moving);
            var movingValue = new Vector2((float) boxingMovingValue,0);

            mover.Moving(movingValue);
        }
    }
}