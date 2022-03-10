using System;
using UnityEngine;


namespace SandBox.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterInfo info;

        public CharacterInfo Info => info;

        private void Start()
        {
            info.health.ResetCurrentByValue();
            info.damage.ResetCurrentByValue();
        }
    }
}