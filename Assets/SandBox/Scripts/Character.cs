using UnityEngine;


namespace SandBox.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterInfo info;

        public CharacterInfo Info => info;
    }
}