using System;
using TigerForge;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterHealthBar : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private ProcessBar processBar;

        private CharacterStat HealthStat => character.stats.GetStat(CharacterStatType.Health);
        
        private void Awake()
        {
            HealthStat.OnValueChanged += OnHealthValueChanged;
        }

        private void OnHealthValueChanged()
        {
            processBar.UpdateView(HealthStat.Percent);
            Debug.Log($"{HealthStat.Current}/{HealthStat.Value}");
        }
    }
}
