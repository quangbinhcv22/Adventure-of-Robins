using System;
using UnityEngine;

namespace SandBox.Scripts
{
    public class MonsterDieAnimator : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private MonsterMoving _mover;

        private void Update()
        {
            if (_character.Info.health.Current <= 0)
            {
                _animator.SetTrigger("Die");
                Invoke(nameof(Hide),1f);
                _mover.Move(new Vector2(0,0));
            }
        }
        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
