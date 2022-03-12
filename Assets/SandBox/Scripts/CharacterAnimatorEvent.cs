using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAnimatorEvent : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Transform shootPoint;
        
        
        public void InstantiateArrow()
        {
            var newArrow = objectPooler.SpawnFromPool(ObjectName.Arrow, shootPoint.position, shootPoint.rotation);
            newArrow.GetComponent<Arrow>().ShootArrow();
        }
    }
}
