
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    public GameObject UIObject;
    private static Player instance = null;
    private SpriteRenderer sprite;
    
    [Header("Movement")]
    [SerializeField] private LayerMask platformsLayerMask;
    public float jumpVelocity = 100f;
    public float moveSpeed = 40f;
    
    public Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;
    private bool waitForStart;
    private bool isDead;
    
    [Header("Shooter")]
    public GameObject bulletPrefab;
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
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        UIObject.SetActive(false);
        
    }
    public void Jump(float value)
    { 
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0,value), ForceMode2D.Impulse);
        }
         
    }
    

    private void Update() {
        if (isDead) return;
        
        if (Input.GetKey(KeyCode.A) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shooter();
        }

        if (sprite.isVisible == false)
        {
            Die();
            SceneManager.LoadScene(2);
        }
        if (moveSpeed <= 0)
        {
            moveSpeed = 1;
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            Jump(jumpVelocity);
        }
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }
    
    public void HandleMovement() {
       if(PlayerInputHandler.playerCount == 2 && Input.GetKey(KeyCode.Space))
        {
       
        }
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        print("velocité x : " + rb.velocity.x);
    }
    
    private void Die() {
        isDead = true;
        rb.velocity = Vector3.zero;
    }

    public static void Die_Static() {
        instance.Die();
        
    }
    

    public void Shooter()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(2f, 0, 0), transform.rotation);
        
        Rigidbody2D Bulletrb = bullet.GetComponent<Rigidbody2D>();
        Bulletrb.velocity = new Vector2(speedOfTheBullet, Bulletrb.velocity.y);
        Destroy(bullet, 3f);
        
    }

    
}
