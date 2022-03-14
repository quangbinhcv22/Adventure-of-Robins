using System;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        
        public void Moving(CharacterMovement characterMovement)
        {
            switch (characterMovement.characterID)
            {
                case CharacterID.Gladiator:
                {
                    mover.Moving(characterMovement.direction);
                    break;
                }
                case CharacterID.RobinHood:
                {
                    mover.Moving(characterMovement.direction);
                    break;
                }
            }
        }
    }
}