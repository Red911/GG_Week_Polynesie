using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetween;

    private float platformWidth;
    
    public float distanceBetweenmin;
    public float distanceBetweenMax;

    public GameObject[] platforms;
    private int platformSelector;
    private float[] platformWidths;

    //public ObjectPooler objPool;
    
    void Start()
    {
        // platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

        platformWidths = new float[platforms.Length];

        for (int i = 0; i < platforms.Length; i++)
        {
            platformWidths[i] = platforms[i].GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenmin, distanceBetweenMax);
            
            platformSelector = Random.Range(0,platforms.Length);
            
            transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distanceBetween, transform.position.y, transform.position.z);

            
            
            Instantiate(platforms[platformSelector], transform.position, transform.rotation);

            // GameObject newPlatform = objPool.GetPoolObject();
            //
            // newPlatform.transform.position = transform.position;
            // newPlatform.transform.position = transform.position;
            // newPlatform.SetActive(true);
        }
    }
}
