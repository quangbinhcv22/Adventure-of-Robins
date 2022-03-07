using UnityEngine;


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
            
            // var temp1 = stats;
             var temp = stats.GetStat(CharacterStatType.Health);
             Debug.Log(temp);
            //
            // stats.GetStat(CharacterStatType.Health).ResetCurrentByValue();
            //
            // stats.AddStat(CharacterStatType.Damage,new CharacterStat(100));
        }
        
    }
}