using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        HandleMovement();
    }
    public void HandleMovement() {
        
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        
    }
}
