
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterHealthBar : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private ProcessBar processBar;

        
        
        private void Awake()
        {
            character.Health.OnValueChanged += OnHealthValueChanged;
        }

        private void OnHealthValueChanged()
        {
            processBar.UpdateView(character.Health.Percent);
            Debug.Log($"{character.Health.Current}/{character.Health.Value}");
        }
    }
}
