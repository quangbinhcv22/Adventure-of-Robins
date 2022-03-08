using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace SandBox.Scripts
{
    
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private GameEvent.EventName.ItemsName itemsName;
        [SerializeField] private Vector3 offset;
        [SerializeField] private float speed;
        [SerializeField] private float xRange;
        [SerializeField] private float zRange;
        [SerializeField] private new SpriteRenderer renderer;
        [SerializeField] private new Rigidbody2D rigidbody2D;

        private float _timeCounter = 0;
        
        private void Update()
        {
            ItemsActivate();
        }

        private void ItemsActivate()
        {
            switch (itemsName)
            {
                case GameEvent.EventName.ItemsName.Sword:
                {
                    FlyAroundPoint();
                    break;
                }
                case GameEvent.EventName.ItemsName.Arrow:
                {
                    ShootArrow();
                    break;
                }
            }
        }

        private void FlyAroundPoint()
        {
            _timeCounter += Time.deltaTime * speed;
            var x = Mathf.Cos(_timeCounter) * xRange;
            var z = Mathf.Sin(_timeCounter);
            
            renderer.sortingOrder = transform.localPosition.z >= 0 ? 10 : 0;
            transform.localPosition = new Vector3(x , 0, z) + offset;
        }
        
        private void ShootArrow()
        {
            var arrowFlyVelocity = rigidbody2D.velocity;
            arrowFlyVelocity.x = speed;

            rigidbody2D.velocity = arrowFlyVelocity;
        }

        
    }
}
