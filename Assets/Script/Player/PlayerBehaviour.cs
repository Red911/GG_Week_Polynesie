using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float gravity;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float jumpVelocity = 20f;
    public float groundHeight = 10f;
    private bool isGrounded;
    private Vector2 velocity;
   
    
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                
                velocity.y = jumpVelocity;
            }
        }
    }
    
    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (!isGrounded)
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime;

            if (pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        }

        transform.position = pos;
    }
}
