using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetween;

    private float platformWidth;
    
    public float distanceBetweenmin;
    public float distanceBetweenMax;

    //public GameObject[] platforms;
    private int platformSelector;
    private float[] platformWidths;

    public ObjectPooler[] objPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;
    
    void Start()
    {
        // platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[objPools.Length];

        for (int i = 0; i < objPools.Length; i++)
        {
            platformWidths[i] = objPools[i].poolObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
    }

    

    
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenmin, distanceBetweenMax);
            
            platformSelector = Random.Range(0,objPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if( heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2)+ distanceBetween, heightChange, transform.position.z);

            // Instantiate(platforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = objPools[platformSelector].GetPoolObject();
            
            newPlatform.transform.position = transform.position;
            newPlatform.transform.position = transform.position;
            newPlatform.SetActive(true);
            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] /2)+ distanceBetween, transform.position.y, transform.position.z);
        }
    }
}
