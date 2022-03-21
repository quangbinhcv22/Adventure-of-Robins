using TigerForge;
using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterMoveInput : MonoBehaviour
    {
        [SerializeField] private CharacterMove characterMove;
        [SerializeField] private CharacterJump characterJump;
        private void Start()
        {
            EventManager.StartListening("Moving",Moving);
            EventManager.StartListening("Jumping",Jumping);
        }

        private void OnDisable()
        {
            EventManager.StopListening("Moving",Moving);
            EventManager.StopListening("Jumping",Jumping);
        }

        private void Moving()
        {
            var boxingMovingValue = EventManager.GetData("Moving");
            var movingValue = (int) boxingMovingValue;
        
            characterMove.Moving(movingValue);
        }

        private void Jumping()
        {
            characterJump.Jump();
        }
    }
}