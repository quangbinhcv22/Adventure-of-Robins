using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAnimatorEvent : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;
        [SerializeField] private Transform shootPoint;
        
        
        public void InstantiateArrow()
        {
            //var newArrow = objectPooler.SpawnFromPool(ObjectName.Arrow, shootPoint.position, shootPoint.rotation);
            var newArrow = objectPooler.GetPooledObject(ObjectName.Arrow);
            
            newArrow.GetComponent<Arrow>().ShootArrow();
        }
    }
}
