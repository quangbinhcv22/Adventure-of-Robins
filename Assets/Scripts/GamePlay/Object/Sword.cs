using System.Collections;
using GamePlay.Character.Offline;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Object
{
    public class Sword : MonoBehaviour
    {
        [SerializeField] public float damage;
        [SerializeField] private GameObject enemyBloodPrefab;
       

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character.Character>();
            if (!targetCharacter) return;
            if (targetCharacter.Info.Team != CharacterTeam.Hostile) return;
            targetCharacter.Info.Health.Current -= damage;
            if (targetCharacter.Info.Health.Current <= 0)
            {
                Scoring.AddPoint(targetCharacter.point);
            }
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