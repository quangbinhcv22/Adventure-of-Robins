using UnityEngine;

namespace SandBox.Scripts
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField] private float damage;

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var targetCharacter = collider2D.GetComponent<Character>();
            if (targetCharacter)
            {
                targetCharacter.Health.Current -= damage;
            }
        }
    }
}
