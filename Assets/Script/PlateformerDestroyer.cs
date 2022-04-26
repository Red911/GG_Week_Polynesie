using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformerDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlateformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
