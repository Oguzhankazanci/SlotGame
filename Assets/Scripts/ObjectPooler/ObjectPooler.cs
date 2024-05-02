using System.Collections.Generic;
using UnityEngine;
namespace ObjectPool
{
    public class ObjectPooler : MonoBehaviour, IObjectPooler
    {

        private Dictionary<GameObject, List<GameObject>> pooledObjects = new Dictionary<GameObject, List<GameObject>>();

        public void InitializePool(GameObject prefab, int poolSize, Transform parent)
        {
            if (!pooledObjects.ContainsKey(prefab))
            {
                List<GameObject> objectList = new List<GameObject>();
                for (int i = 0; i < poolSize; i++)
                {
                    GameObject obj = Instantiate(prefab, parent);
                    obj.SetActive(false);
                    objectList.Add(obj);
                }
                pooledObjects.Add(prefab, objectList);
            }
        }

        public GameObject GetPooledObject(GameObject prefab)
        {
            if (pooledObjects.ContainsKey(prefab))
            {
                foreach (GameObject obj in pooledObjects[prefab])
                {
                    if (!obj.activeInHierarchy)
                    {
                        obj.SetActive(true);
                        return obj;
                    }
                }
            }

            GameObject newObj = Instantiate(prefab);
            newObj.SetActive(true);
            if (!pooledObjects.ContainsKey(prefab))
            {
                pooledObjects.Add(prefab, new List<GameObject>());
            }
            pooledObjects[prefab].Add(newObj);
            return newObj;
        }

        public void ReturnObjectToPool(GameObject obj)
        {
            obj.SetActive(false);
        }
    }
    public interface IObjectPooler
    {
        void InitializePool(GameObject prefab, int poolSize, Transform parent);
        GameObject GetPooledObject(GameObject prefab);
        void ReturnObjectToPool(GameObject obj);
    }
}