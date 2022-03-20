
using SandBox.Scripts;
using UnityEngine;
using CharacterInfo = SandBox.Scripts.CharacterInfo;

namespace GamePlay.Character
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterInfo info;
        [SerializeField] private ObjectPooler objectPooler;
       
        public CharacterInfo Info => info;

        private void Start()
        {
            info.health.ResetCurrentByValue();
            info.damage.ResetCurrentByValue();
        }
    }
}