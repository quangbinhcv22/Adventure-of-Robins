using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterTakeDame : MonoBehaviour
    {
        [SerializeField] private Character character;
        private void Start()
        {
            EventManager.StartListening(EventName.Mechanism.Character.TakeDamage(character.ID),TakeDamage);
        }

        private void TakeDamage()
        {
            var boxingTakeDameValue = EventManager.GetData(EventName.Mechanism.Character.TakeDamage(character.ID));
            var takeDameValue = (float) boxingTakeDameValue;
            Debug.Log(takeDameValue);
            character.OnHealthChange(takeDameValue);
            
        }
    }
}
