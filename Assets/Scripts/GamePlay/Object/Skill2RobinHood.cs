using System;
using System.Collections;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Object
{
    public class Skill2RobinHood : MonoBehaviour
    {
        [SerializeField] private Arrow arrow;
        
        public IEnumerator ActiveBuff()
        {
            Buff();
            yield return new WaitForSeconds(3f);
            Debuff();
            
        }

        private void Debuff()
        {
            arrow.CurrentDamage -= 100;
        }

        private void Buff()
        {
            arrow.CurrentDamage += 100;
        }

    }
}
