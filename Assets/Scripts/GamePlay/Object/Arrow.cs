using System;
using System.Collections;
using GamePlay.Enum;
using SandBox.Scripts;
using TMPro;
using UnityEngine;

namespace GamePlay.Object
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] public float damage;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float objectForce;
        [SerializeField] private GameObject enemyPrefab;

        private float _currentDamage;

        public float CurrentDamage
        {
            get => _currentDamage;
            set => _currentDamage = value;
        }

        private void Start()
        {
            _currentDamage = 0;
        }

        public void ShootArrow(Side side)
        {
            var arrowFlyVelocity = rigidbody2D.velocity;
            arrowFlyVelocity.x = objectForce * (int)side;

            rigidbody2D.velocity = arrowFlyVelocity;
        }
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character.Character>();
            if (!targetCharacter) return;
            if (targetCharacter.Info.Team != CharacterTeam.Hostile) return;
            targetCharacter.Info.Health.Current -= damage + _currentDamage;
                    
            InstantiateParticle(enemyPrefab,targetCharacter.transform);
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
