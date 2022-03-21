using UnityEngine;

namespace UI
{
    public class Parallax : MonoBehaviour
    {
        private float _length, _startpos;
        public GameObject cam;
        public float parallaxEffect;
        void Start()
        {
            _startpos = transform.position.x;
            _length = GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void FixedUpdate()
        {
            var dist = (cam.transform.position.x * parallaxEffect);
            transform.position = new Vector3(_startpos + dist, transform.position.y, transform.position.z);
        }
    }
}
