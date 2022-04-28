using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coconut : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("toucher");
        }
        else if (col.gameObject.tag == "Fire" || col.gameObject.tag == "Ground") 
        {
            Destroy(gameObject);
        }
        
    }
}
