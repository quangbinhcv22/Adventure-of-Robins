using System.Collections;
using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterAttack : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Transform shootPoint;

        public void InstantiateArrow()
        {
            Instantiate(arrowPrefab,shootPoint);
        }
    }
}
