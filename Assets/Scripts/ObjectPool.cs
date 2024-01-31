using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> objectPools = new List<PooledObjectInfo>();

    public static GameObject SpawnObject(GameObject objectToSpawn, Transform parentTransform)
    {
        PooledObjectInfo pool = objectPools.Find(p => p.lookUpString == objectToSpawn.name);

        if (pool == null)
        {
            pool = new PooledObjectInfo
            {
                lookUpString = objectToSpawn.name
            };

            objectPools.Add(pool);
        }

        GameObject go = pool.inactiveObjects.FirstOrDefault();

        if (go == null)
        {
            go = Instantiate(objectToSpawn, parentTransform);
        }
        else
        {
            pool.inactiveObjects.Remove(go);
            go.SetActive(true);
        }

        return go;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        string goName = obj.name.Substring(0, obj.name.Length - 7);

        PooledObjectInfo pool = objectPools.Find(p => p.lookUpString == goName);

        if (pool != null)
        {
            obj.SetActive(false);
            pool.inactiveObjects.Add(obj);
        }

    }
}

public class PooledObjectInfo
{
    public string lookUpString;
    public List<GameObject> inactiveObjects = new List<GameObject>();
}
