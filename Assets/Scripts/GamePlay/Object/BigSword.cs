using System;
using GamePlay.Enum;
using SandBox.Scripts;
using UnityEngine;

namespace GamePlay.Object
{
    public class BigSword : MonoBehaviour
    {
        [SerializeField] private ObjectPooler objectPooler;


        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (!collider2D.CompareTag("Ground")) return;
            var newObjectPooler = objectPooler.GetPooledObject(ObjectName.DirtParticle);
            
            newObjectPooler.transform.position = transform.position;
            newObjectPooler.transform.rotation = transform.rotation;
        }
    }
}
