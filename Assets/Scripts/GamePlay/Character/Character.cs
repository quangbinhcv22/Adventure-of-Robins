
using System;
using SandBox.Scripts;
using UnityEngine;
using UnityEngine.Events;
using CharacterInfo = GamePlay.Character.CharacterInfo;

namespace GamePlay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterInfo info;
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] public int point;
        public CharacterInfo Info => info;

        public UnityEvent onDie;
        
        
        private void Start()
        {
            info.health.ResetCurrentByValue();
            info.damage.ResetCurrentByValue();
        }

        private void FixedUpdate()
        {
            if(info.id == "Player" && info.health.Current <= 0) onDie.Invoke();
        }
    }
}