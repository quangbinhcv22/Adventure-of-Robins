using System;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private Mover mover;
        
        public void Moving(CharacterMovement characterMovement)
        {
            switch (characterMovement.heroID)
            {
                case HeroID.Gladiator:
                {
                    mover.Moving(characterMovement.direction);
                    break;
                }
                case HeroID.RobinHood:
                {
                    mover.Moving(characterMovement.direction);
                    break;
                }
            }
        }
    }
}