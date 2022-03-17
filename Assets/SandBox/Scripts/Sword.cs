using System;
using System.Collections;
using DG.Tweening;
using TigerForge;
using TMPro;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] public float damage;
        // [SerializeField] private Character character;
        // [SerializeField] private ObjectName objectName;
        [SerializeField] private GameObject enemyPrefab;
       

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                if (targetCharacter.Info.Team ==  CharacterTeam.Hostile)
                {
                    targetCharacter.Info.Health.Current -= damage;
                    
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