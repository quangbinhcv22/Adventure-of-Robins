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
                EventManager.EmitEventData(GameEvent.EventName.CharacterInput.Moving,-1f);
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.StartRunAnimation);
            }
            if (Input.GetKey(KeyCode.D))
            {
                EventManager.EmitEventData(GameEvent.EventName.CharacterInput.Moving,1f);
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.StartRunAnimation);
            }
            if (Input.GetKeyUp(KeyCode.D) ||Input.GetKeyUp(KeyCode.A))
            {
                EventManager.EmitEventData(GameEvent.EventName.CharacterInput.Moving,0f);
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.StartIdleAnimation);
            }
            if (Input.GetKey(KeyCode.K))
            {
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Jump);
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.StartJumpAnimation);
            }
            if (Input.GetKey(KeyCode.J))
            {
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Attack);
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.StartAttackAnimation);
            }
            if (Input.GetKey(KeyCode.U))
            {
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Skill1);
            }

            if (Input.GetKey(KeyCode.I))
            {
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Skill2);
            }

            if (Input.GetKey(KeyCode.O))
            {
                EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Skill3);
            }
            EventManager.EmitEvent(GameEvent.EventName.CharacterInput.Fall);
            EventManager.EmitEvent(GameEvent.EventName.CharacterInput.FallDuringRun);
            EventManager.EmitEvent(GameEvent.EventName.CharacterInput.IsLanding);
        }
    }
}
