using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformGenerator : MonoBehaviour
{
    public GameObject platform;
    public Transform generationPoint;
    private float distanceBetween;

    private float platformWidth;
    
    public float distanceBetweenmin;
    public float distanceBetweenMax;

    public ObjectPooler objPool;
    
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenmin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            // Instantiate(platform, transform.position, transform.rotation);

            GameObject newPlatform = objPool.GetPoolObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.position = transform.position;
            newPlatform.SetActive(true);
        }
    }
}
