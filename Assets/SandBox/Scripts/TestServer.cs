using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class TestServer : MonoBehaviour
    {
        private void Update()
        {
            EventManager.EmitEventData("CharacterMove",
                new CharacterMovement(CharacterID.Gladiator,new Vector2(1,0)) );
            EventManager.EmitEventData("CharacterJump",
                new CharacterMovement(CharacterID.Gladiator,new Vector2(0,1)) );
            //EventManager.EmitEventData("CharacterAttack",CharacterAttack);
            // EventManager.EmitEventData("CharacterTakeDame",CharacterTakeDame);
        }
    }
}