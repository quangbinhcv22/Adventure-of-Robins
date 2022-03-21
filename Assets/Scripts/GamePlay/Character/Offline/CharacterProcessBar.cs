using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterProcessBar : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private ProcessBar processBar;

        private void Awake()
        {
            character.onValueChanged += OnHealthChangeValue;
        }

        private void OnHealthChangeValue()
        {
            switch (processBar.processBarName)
            {
                case ProcessBarName.HealthBar:
                    processBar.UpdateProcessBar(character.CurrentHealth,character.MaxHealth);
                    break;
            }
        }
    }
}