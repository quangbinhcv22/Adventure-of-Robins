using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAnimatorEvent : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Transform shootPoint;
        
        
        public void InstantiateArrow()
        {
            var arrow = Instantiate(arrowPrefab,shootPoint);
            var newArrow = arrow.GetComponent<Arrow>();
            
            newArrow.ShootArrow();
        }
    }
}
