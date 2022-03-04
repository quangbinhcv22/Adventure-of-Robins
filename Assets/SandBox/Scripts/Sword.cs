using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Sword : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                EventManager.EmitEventData(EventName.Mechanism.Character.TakeDamage(targetCharacter.ID),
                    100);
            }
        }
    }
}