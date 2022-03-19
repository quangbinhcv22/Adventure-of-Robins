using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Skill2RobinHood : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private ObjectPooler objectPooler;
        
        public IEnumerator ActiveBuff()
        {
            Buff();
            yield return new WaitForSeconds(5f);
            Debuff();
        }

        private void Update()
        {
            Buff();
        }

        private void Debuff()
        {
            character.Info.damage.Current -= 100;
            
        }

        private void Buff()
        {
            character.Info.damage.Current += 100;
            
        }
    }
}
