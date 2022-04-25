using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float groundHeight;
    private BoxCollider2D collider;
    
    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        groundHeight = 1 + transform.position.y + (collider.size.y / 2f);
    }

    void Update()
    {
       
    }
}
