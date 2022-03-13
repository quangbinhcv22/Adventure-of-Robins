using Network.Events;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterJump : MonoBehaviour
    {
        [SerializeField] private Jumper jumper;
        
        public void Jumping(CharacterJumpEvent characterJumpEvent)
        {
            // switch (characterJumpEvent.characterID)
            // {
            //     case CharacterID.Gladiator:
            //     {
            //         jumper.SetCanJump(true);
            //         jumper.SetJumpForce(20f);
            //         jumper.SetMaxCount(2);
            //         break;
            //     }
            //     case CharacterID.RobinHood:
            //     {
            //         jumper.SetCanJump(true);
            //         jumper.SetJumpForce(20f);
            //         jumper.SetMaxCount(2);
            //         break;
            //     }
            // }
        }
        
    }
}