using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterMovement 
    {
        public string characterID;
        public Vector2 direction;

        public CharacterMovement(string characterID, Vector2 direction)
        {
            this.characterID = characterID;
            this.direction = direction;
        }
    }
}