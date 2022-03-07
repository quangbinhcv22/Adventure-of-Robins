using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] private float damage;

            private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                targetCharacter.stats.GetStat(CharacterStatType.Health).Current -= 100;
            }
        }
    }
}