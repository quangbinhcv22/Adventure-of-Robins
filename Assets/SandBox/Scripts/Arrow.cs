using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] public float damage;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float objectForce;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private Character _character;
        
        

        public void ShootArrow()
        {
            var arrowFlyVelocity = rigidbody2D.velocity;
            arrowFlyVelocity.x = objectForce;

            rigidbody2D.velocity = arrowFlyVelocity;
        }
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                if (targetCharacter.Info.Team == CharacterTeam.Hostile)
                {
                    targetCharacter.Info.Health.Current -= damage + _character.Info.damage.Current;
                    
                    InstantiateParticle(enemyPrefab,targetCharacter.transform);
                }
            }
        }
        private void InstantiateParticle(GameObject particlePrefab, Transform targetCharacter)
        {
            var newEnemyBlood = Instantiate(particlePrefab, targetCharacter.position,
                targetCharacter.rotation);

            StartCoroutine(DestroyGameobject(newEnemyBlood));
        }
        private IEnumerator DestroyGameobject(GameObject gameObject)
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}
