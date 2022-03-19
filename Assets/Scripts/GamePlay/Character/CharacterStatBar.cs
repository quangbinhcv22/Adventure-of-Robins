
using System;
using GamePlay.Character;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterStatBar : MonoBehaviour
    {
        [SerializeField] private CharacterStatType statType;
        [SerializeField] private Character character;
        [SerializeField] private ProcessBar processBar;

        
        private void Awake()
        {
            character.Info.Health.OnValueChanged += OnHealthValueChanged;
        }
        

        private void OnHealthValueChanged()
        {
            processBar.UpdateView(character.Info.Health.Percent);
            Debug.Log($"{character.Info.Health.Current}/{character.Info.Health.Value}");
        }
    }
}
