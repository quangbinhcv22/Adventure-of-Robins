using TigerForge;
using UnityEngine;
using UnityEngine.UI;

namespace GamePlay.Character.Offline
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
                EventManager.EmitEvent("Skill1");
            }

            if (Input.GetKey(KeyCode.I))
            {
                EventManager.EmitEvent("Skill2");
            }

            if (Input.GetKey(KeyCode.O))
            {
                EventManager.EmitEvent("Skill3");
            }

            if (character.Info.Health.Current == 0)
            {
                EventManager.EmitEvent("DieAnimation");
            }

            if (Input.GetKey(KeyCode.Space))
            {
                character.Info.Health.Current += 1000;
            }
        }
    }
}