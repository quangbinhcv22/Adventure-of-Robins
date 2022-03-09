using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterJumping : MonoBehaviour
    {
        public string characterID;
        public Vector2 direction;

        public CharacterJumping(string characterID, Vector2 direction)
        {
            this.characterID = characterID;
            this.direction = direction;
        }
    }
}