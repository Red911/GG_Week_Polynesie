/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using UnityEngine;


/*
 * Simple Jump
 * */
public class Player : MonoBehaviour {

    private static Player instance;
    
    [Header("Movement")]
    [SerializeField] private LayerMask platformsLayerMask;
    public float jumpVelocity = 100f;
    public float moveSpeed = 40f;
    
    [SerializeField] private Rigidbody2D rigidbody2d;
    [SerializeField] private BoxCollider2D boxCollider;
    private bool waitForStart;
    private bool isDead;

    private void Awake() {
        instance = this;
        waitForStart = true;
        isDead = false;
    }

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        if (isDead) return;
        if (waitForStart) {
            
            if (Input.GetKeyDown(KeyCode.Space)) {
                waitForStart = false;
            }
        } else {
            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) {
                
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
            }

            HandleMovement();

            
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
    
    private void HandleMovement() {
        
        rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
    }
    
    private void Die() {
        isDead = true;
        rigidbody2d.velocity = Vector3.zero;
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

}
