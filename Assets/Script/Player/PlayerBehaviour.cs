using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement")]
    public float gravity;
    public float distance = 0f;
    public Vector2 velocity;
    public float maxVelocity = 100f;
    public float maxAcceleration = 10;
    public float acceleration = 10;
    public float jumpVelocity = 20f;
    public float groundHeight = 10f;
    public bool isGrounded;
    
   
    
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

            Vector2 rayOrigin = new Vector2(pos.x + 0.7f, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = velocity.y * Time.fixedDeltaTime;
            // if (pos.y <= groundHeight)
            // {
            //     pos.y = groundHeight;
            //     isGrounded = true;
            // }
        }

        distance += velocity.x * Time.fixedDeltaTime;
        
        if (isGrounded)
        {
            float velocityRatio = velocity.x / maxVelocity;
            acceleration = maxAcceleration * (1 - velocityRatio);
            
            velocity.x += acceleration * Time.fixedDeltaTime;
            if (velocity.x >= maxVelocity)
            {
                velocity.x = maxVelocity;
            }
        }

        transform.position = pos;
    }
}
