using SandBox.Scripts;
using TigerForge;
using UnityEngine;

namespace GamePlay.MovementSimulation
{
    public class CharacterEventManager : MonoBehaviour
    {
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask ground;
        
        private bool _isLanding;

        private void Update()
        {
            _isLanding = CharacterCheckTounching.IsTouchingLayer(groundCheck, ground);

            switch (_isLanding)
            {
               
                //EventManager.EmitEvent(CharacterInput.Fall);
                case false:
                    EventManager.EmitEvent(CharacterInput.FallDuringRun);
                    break;
                case true:
                    EventManager.EmitEvent(CharacterInput.IsLanding);
                    break;
            }
        }
    }
}
