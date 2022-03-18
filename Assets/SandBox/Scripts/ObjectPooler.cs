using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandBox.Scripts
{
    public class ObjectPooler : MonoBehaviour
    {
        public Dictionary<ObjectName, Queue<GameObject>> poolDictionary;
        public List<ObjectPool> objectPools;

        private void Start()
        {
            poolDictionary = new Dictionary<ObjectName, Queue<GameObject>>();

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

        public GameObject SpawnFromPool(ObjectName objectName, Vector3 position,
            Quaternion rotation)
        {
            GameObject objectToSpawn = poolDictionary[objectName].Dequeue();
            
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            
            poolDictionary[objectName].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        public IEnumerator HideObject(GameObject gameObject, float duration)
        {
            yield return new WaitForSeconds(duration);
            Hide(gameObject);
        }
        
        private void Hide(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}