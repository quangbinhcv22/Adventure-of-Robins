using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Serialization;

namespace SandBox.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private string id;

        public CharacterStats stats;
        // [SerializeField] private CharacterStat strength;
        // [SerializeField] private CharacterStat vitality;
        // [SerializeField] private CharacterStat dexterity;
        // [SerializeField] private CharacterStat intelligence;
        // [SerializeField] private CharacterStat damage;

        public string ID => id;
        
        private void Start()
        {
            stats.AddStat(CharacterStatType.Health,new CharacterStat(1000));
            Debug.Log(stats.GetStat(CharacterStatType.Health).Value);

            stats.GetStat(CharacterStatType.Health).ResetCurrentByValue();
            
            stats.AddStat(CharacterStatType.Damage,new CharacterStat(100));
        }

        public void OnHealthChange(float damage)
        {
            stats.GetStat(CharacterStatType.Health).Current -= damage;
        }
    }
}