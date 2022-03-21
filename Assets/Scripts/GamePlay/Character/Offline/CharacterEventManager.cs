using TigerForge;
using UnityEngine;

namespace GamePlay.Character
{
    public class CharacterEventManager : MonoBehaviour
    {
        [SerializeField] private Character character;

        void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                EventManager.EmitEventData("Moving", -1);
                EventManager.EmitEvent("RunAnimator");
                
            }

            if (Input.GetKey(KeyCode.D))
            {
                EventManager.EmitEventData("Moving", 1);
                EventManager.EmitEvent("RunAnimator");
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                EventManager.EmitEventData("Moving", 0);
                EventManager.EmitEvent("IdleAnimator");
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                EventManager.EmitEvent("Attacking");
                EventManager.EmitEvent("AttackAnimator");
                
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                EventManager.EmitEvent("Jumping");
                EventManager.EmitEvent("JumpAnimator");
            }

            if (Input.GetKey(KeyCode.U))
            {

            }

            if (Input.GetKey(KeyCode.I))
            {

            }

            if (Input.GetKey(KeyCode.O))
            {

            }
            EventManager.EmitEvent("FallAfterRunAnimator");
            if (character.Info.Health.Current == 0)
            {
                EventManager.EmitEvent("DieAnimation");
            }
        }
    }
}