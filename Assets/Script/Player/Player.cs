﻿
using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour {

    private static Player instance;
    
    [Header("Movement")]
    [SerializeField] private LayerMask platformsLayerMask;
    public float jumpVelocity = 100f;
    public float moveSpeed = 40f;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    private bool waitForStart;
    private bool isDead;
    
    [Header("Shooter")]
    public GameObject bulletPrefab;
    public Transform gun;
    public float fireRate = 1f;
    private float nextFire = 0f;
    public float speedOfTheBullet = 20f;

    private void Awake() {
        instance = this;
        waitForStart = true;
        isDead = false;
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (waitForStart)
            {
                waitForStart = false;
            }
            else 
            {
                if (IsGrounded())
                {
                    rb.velocity = Vector2.up * jumpVelocity;
                }
                
                HandleMovement();
            }
            
        }
    }
    

    private void Update() {
        if (isDead) return;
        
        if (Input.GetKey(KeyCode.A) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shooter();
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
    
    private void HandleMovement() {
        
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
    }
    
    private void Die() {
        isDead = true;
        rb.velocity = Vector3.zero;
    }

    public static void Die_Static() {
        instance.Die();
        
    }
    
    void OnDrawGizmosSelected()
    {
        if (IsGrounded())
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        
        Gizmos.DrawCube(boxCollider.bounds.center, boxCollider.bounds.size);
    }

    private void Shooter()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.rotation);
        
        Rigidbody2D Bulletrb = bullet.GetComponent<Rigidbody2D>();
        Bulletrb.velocity = new Vector2(speedOfTheBullet, Bulletrb.velocity.y);
        Destroy(bullet, 3f);
        
    }

    
}
