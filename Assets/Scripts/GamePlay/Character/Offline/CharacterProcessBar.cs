using UnityEngine;

namespace GamePlay.Character.Offline
{
    public class CharacterProcessBar : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private ProcessBar processBar;

        private void Awake()
        {
            character.Info.health.OnValueChanged += OnHealthChangeValue;
        }

        private void OnHealthChangeValue()
        {
            switch (processBar.processBarName)
            {
                case ProcessBarName.HealthBar:
                    processBar.UpdateProcessBar(character.Info.Health.Percent,character.Info.health.BaseValue);
                    break;
            }
        }
    }
}