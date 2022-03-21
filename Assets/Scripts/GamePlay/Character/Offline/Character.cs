using UnityEngine;
using UnityEngine.Events;

namespace GamePlay.Character.Offline
{
    public class Character : MonoBehaviour
    {
        [SerializeField] public CharacterID characterID;
        [SerializeField] private float maxHealth;
        [SerializeField] private float currentHealth;
        [SerializeField] private float currentMana;
        [SerializeField] private float maxMana;

        public UnityEvent onDie;
        public UnityEvent onWin;
        public float MaxHealth => maxHealth;
        public float MaxMana => maxMana;
        
        public UnityAction onValueChanged;

        public float CurrentHealth
        {
            get => currentHealth;

            set
            {
                currentHealth = value;
                if (currentHealth > maxHealth) currentHealth = maxHealth;
                if (currentHealth < 0) currentHealth = 0;
                if (currentHealth == 0) onDie.Invoke();
                onValueChanged?.Invoke();
                
            }
        }
        public float CurrentMana
        {
            get => currentMana;

            set
            {
                currentMana = value;
                if (currentMana > maxMana) currentMana = maxMana;
                onValueChanged?.Invoke();
            }
        }

        private void OnValidate()
        {
            currentHealth = maxHealth;
            currentMana = maxMana;
        }
        
        public void OnDie()
        {
            if (!(CurrentHealth <= 0)) return;

            switch (characterID)
            {
                case CharacterID.Monster:
                    Hide();
                    break;
            }
        }
        private void Hide()
        {
            Destroy(gameObject);
        }
    }
}