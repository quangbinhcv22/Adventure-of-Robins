using DG.Tweening;
using UnityEngine;

namespace SandBox.Scripts
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] ObjectName objectName;
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private float objectForce;

        
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
                    targetCharacter.Info.Health.Current -= damage;
                }
            }
        }
    }
}
