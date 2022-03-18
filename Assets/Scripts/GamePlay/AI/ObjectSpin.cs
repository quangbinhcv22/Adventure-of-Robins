using UnityEngine;

namespace GamePlay.AI
{
    public class ObjectSpin : MonoBehaviour
    {
        [SerializeField] private float spinSpeed;
        private void Update()
        {
            gameObject.transform.Rotate(new Vector3(0,0 , spinSpeed));
        }
    }
}
