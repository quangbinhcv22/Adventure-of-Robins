using System.Collections;
using GamePlay.Enum;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.AI
{
    public class MonsterDieAnimator : MonoBehaviour
    {
        [SerializeField] private Character.Character _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private MonsterMoving _mover;
        [SerializeField] private ObjectPooler particlePooler;

        private void Update()
        {
            if (_character.Info.health.Current <= 0)
            {
                _animator.SetTrigger("Die");
                _mover.Move(new Vector2(0,0));
                StartCoroutine(HideGameObject(gameObject,1f));
                
                //var newExplosion = particlePooler.SpawnFromPool(ObjectName.Explosion, transform.position, transform.rotation);
                var newExplosion = particlePooler.GetPooledObject(ObjectName.Explosion);
               
                StartCoroutine(HideGameObject(newExplosion.gameObject,1f));
            }
        }

        private IEnumerator HideGameObject(GameObject gameObject,float duration)
        {
            yield return new WaitForSeconds(duration);
            Hide(gameObject);
        }
        private void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}
