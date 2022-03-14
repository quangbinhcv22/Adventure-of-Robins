using System;
using UnityEngine;

namespace SandBox.Scripts
{
    public class MonsterDieAnimator : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (_character.Info.health.Current == 0)
                _animator.SetTrigger("Die");
        }
    }
}
