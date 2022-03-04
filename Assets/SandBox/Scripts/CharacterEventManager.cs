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
                EventManager.EmitEventData("Moving",-1f);
                EventManager.EmitEvent("StartRunAnimation");
            }
            if (Input.GetKey(KeyCode.D))
            {
                EventManager.EmitEventData("Moving",1f);
                EventManager.EmitEvent("StartRunAnimation");
            }
            if (Input.GetKeyUp(KeyCode.D) ||Input.GetKeyUp(KeyCode.A))
            {
                EventManager.EmitEventData("Moving",0f);
                EventManager.EmitEvent("StartIdleAnimation");
            }
            if (Input.GetKey(KeyCode.K))
            {
                EventManager.EmitEvent("Jump");
                EventManager.EmitEvent("StartJumpAnimation");
            }
            if (Input.GetKey(KeyCode.J))
            {
                EventManager.EmitEvent("Attack");
                EventManager.EmitEvent("StartAttackAnimation");
            }
            EventManager.EmitEvent("Landing");
            EventManager.EmitEvent("FallDuringRun");
        }
    }
}
