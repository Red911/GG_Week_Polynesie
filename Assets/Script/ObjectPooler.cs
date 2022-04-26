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

    
    void Update()
    {
        
    }
}
