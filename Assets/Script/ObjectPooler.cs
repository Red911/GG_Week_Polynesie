using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject poolObject;
    public int pooledAmount;

    private List<GameObject> poolObjects;

    void Start()
    {
        poolObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject) Instantiate(poolObject);
            obj.SetActive(false);
            poolObjects.Add(obj);
        }

    }

    
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }
        
        GameObject obj = (GameObject) Instantiate(poolObject);
        obj.SetActive(false);
        poolObjects.Add(obj);
        return obj;
    }
}
