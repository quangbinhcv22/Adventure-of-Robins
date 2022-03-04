using UnityEngine;

namespace SandBox.Scripts
{
    public class CharacterCamFollow : MonoBehaviour
    {
        public Transform player;
        public Vector3 offset;

        void Update()
        {
            var position = player.position;
            transform.position = new Vector3(position.x + offset.x, position.y + offset.y, offset.z);
        }
    }
}
