using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GamePlay.Enum;
using QBStudio.Collection;
using UnityEngine;

namespace SandBox.Scripts
{
    public class ObjectPooler : MonoBehaviour
    {
        private readonly Dictionary<ObjectName, List<GameObject>> _poolDictionary = new Dictionary<ObjectName, List<GameObject>>();
        [SerializeField] private SafeQueryDictionary<ObjectName, GameObject> objectPools;

        // public static ObjectPooler Instance;
        // private void Awake()
        // {
        //     Instance = this;
        // }

        public GameObject GetPooledObject(ObjectName objectName)
        {
            if (_poolDictionary.ContainsKey(objectName))
            {
                var pooledObject = _poolDictionary[objectName].Find(pooledObject => pooledObject.activeSelf is false);
                if (pooledObject)
                {
                    pooledObject.SetActive(true);
                    return pooledObject;
                }
            }

            var prefab = objectPools[objectName];
            if (!prefab) return null;
            var newObjectPool = Instantiate(prefab.gameObject);
            if (_poolDictionary.ContainsKey(objectName))
            {
                _poolDictionary[objectName].Add(newObjectPool);
            }
            else
            {
                _poolDictionary.Add(objectName, new List<GameObject> {newObjectPool});
            }
            
            return newObjectPool;
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