
using System.Collections;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] public float damage;
        [SerializeField] private GameObject enemyBloodPrefab;
       

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (!targetCharacter) return;
            if (targetCharacter.Info.Team != CharacterTeam.Hostile) return;
            targetCharacter.Info.Health.Current -= damage;
                    
            InstantiateParticle(enemyBloodPrefab,targetCharacter.transform);
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