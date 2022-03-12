using UnityEngine;

namespace SandBox.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] public ObjectName idObject;
        [SerializeField] public int size;
        [SerializeField] public GameObject objectPrefab;
        // [SerializeField] private Transform[] wayPoints;
        // [SerializeField] private new Rigidbody2D rigidbody2D;
        // [SerializeField] private float objectForce;
        // [SerializeField] private float objectSize;
        // [SerializeField] private float objectSizeDuration;

    }
}