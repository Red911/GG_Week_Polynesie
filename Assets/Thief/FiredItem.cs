using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredItem : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("toucher");
        }
        else if (col.gameObject.tag == "Water") 
        {
            Destroy(gameObject);
        }
        
    }
}
