using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThiefPlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;

    [Header("Spike")] 
    public GameObject spikeSpawn;
    public GameObject spikeprefab;
    public float fireRate = 3f;
    private float nextFire = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpikeSpawner();
        }
        
    }
   
    void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement() 
    {
        if(PlayerInputHandler.playerCount == 2 && Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
            
        }
    }
    
    
    
    public void SpikeSpawner()
    {
        GameObject spike = Instantiate(spikeprefab, spikeSpawn.transform.position, spikeSpawn.transform.rotation);
        
    }
}
