using System;
using System.Collections;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Skill2RobinHood : MonoBehaviour
    {
        [SerializeField] private Character _character;
        

        public IEnumerator ActiveBuff()
        {
            Buff();
            yield return new WaitForSeconds(5f);
            Debuff();
        }
        
        private void Debuff()
        {
            _character.Info.damage.Current -= 100;
        }

        private void Buff()
        {
            _character.Info.damage.Current += 100;
        }
    }
}
