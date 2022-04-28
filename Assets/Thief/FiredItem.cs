using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredItem : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            print("toucher");
        }
        else if (col.gameObject.tag == "Water")
        {
            boxCollider2D.offset = new Vector2(0,0);
        }
        
    }
}
