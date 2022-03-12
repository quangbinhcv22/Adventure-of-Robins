using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterEventManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                EventManager.EmitEventData(CharacterInput.Moving,-1f);
                EventManager.EmitEvent(CharacterInput.StartRunAnimation);
            }
            if (Input.GetKey(KeyCode.D))
            {
                EventManager.EmitEventData(CharacterInput.Moving,1f);
                EventManager.EmitEvent(CharacterInput.StartRunAnimation);
            }
            if (Input.GetKeyUp(KeyCode.D) ||Input.GetKeyUp(KeyCode.A))
            {
                EventManager.EmitEventData(CharacterInput.Moving,0f);
                EventManager.EmitEvent(CharacterInput.StartIdleAnimation);
            }
            if (Input.GetKey(KeyCode.K))
            {
                EventManager.EmitEvent(CharacterInput.Jump);
                EventManager.EmitEvent(CharacterInput.StartJumpAnimation);
            }
            if (Input.GetKey(KeyCode.J))
            {
                EventManager.EmitEvent(CharacterInput.Attack);
                EventManager.EmitEvent(CharacterInput.StartAttackAnimation);
            }
            if (Input.GetKey(KeyCode.U))
            {
                EventManager.EmitEvent(CharacterInput.Skill1);
            }

            if (Input.GetKey(KeyCode.I))
            {
                EventManager.EmitEvent(CharacterInput.Skill2);
            }

            if (Input.GetKey(KeyCode.O))
            {
                EventManager.EmitEvent(CharacterInput.Skill3);
            }
            EventManager.EmitEvent(CharacterInput.Fall);
            EventManager.EmitEvent(CharacterInput.FallDuringRun);
            EventManager.EmitEvent(CharacterInput.IsLanding);
        }
    }
}
