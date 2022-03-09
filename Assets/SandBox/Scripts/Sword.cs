using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private Character character;
        [SerializeField] private GameEvent.EventName.ObjectName objectName;

            private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                if (targetCharacter.Info.Team ==  GameEvent.EventName.CharacterTeam.Hostile)
                {
                    targetCharacter.Info.Health.Current -= damage;
                }
                
            }
        }
    }
}