using UnityEngine;


namespace SandBox.Scripts
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private string id;
        [SerializeField] private CharacterStat health;
        [SerializeField] private CharacterStat damage;

        public CharacterStat Health
        {
            get => health;
        }

        public CharacterStat Damage => damage;

        
        //public CharacterStats stats;
        // [SerializeField] private CharacterStat strength;
        // [SerializeField] private CharacterStat vitality;
        // [SerializeField] private CharacterStat dexterity;
        // [SerializeField] private CharacterStat intelligence;
        // [SerializeField] private CharacterStat damage;

        public string ID => id;
        
        private void Start()
        {
            health.ResetCurrentByValue();
            damage.ResetCurrentByValue();
            
            // stats.AddStat(CharacterStatType.Health,new CharacterStat(1000));
            // stats.GetStat(CharacterStatType.Health).ResetCurrentByValue();
            //
            // stats.AddStat(CharacterStatType.Damage,new CharacterStat(100));
        }
        
    }
}