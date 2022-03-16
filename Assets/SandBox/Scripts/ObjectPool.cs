using UnityEngine;

namespace SandBox.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] public ObjectName idObject;
        [SerializeField] public int size;
        [SerializeField] public GameObject objectPrefab;

    }
}