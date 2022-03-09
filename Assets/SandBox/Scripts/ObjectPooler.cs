using System;
using System.Collections.Generic;
using UnityEngine;

namespace SandBox.Scripts
{
    public class ObjectPooler : MonoBehaviour
    {
        public Dictionary<string, Queue<GameObject>> poolDictionary;
        public List<ObjectPool> objectPools;

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (ObjectPool objectPool in objectPools)
            {
                Queue<GameObject> newObjectsPool = new Queue<GameObject>();
                
                for (var i = 0; i < objectPool.size;i++)
                {
                    GameObject obj = Instantiate(objectPool.objectPrefab);
                    obj.SetActive(false);

                    newObjectsPool.Enqueue(obj);
                }
                poolDictionary.Add(objectPool.idObject,newObjectsPool);
            }
        }

        public GameObject SpawnFromPool(string objectName, Vector3 position,
            Quaternion rotation)
        {
            GameObject objectToSpawn = poolDictionary[objectName].Dequeue();
            
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            poolDictionary[objectName].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
        
    }
}