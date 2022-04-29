using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThiefPlayer : MonoBehaviour
{
    public float moveSpeed = 10f;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Spike")] 
    public bool usedSpike;
    public GameObject spikeSpawn;
    public GameObject spikeprefab;
    public float fireRate = 3f;
    private float nextFire = 0f;
    
    [Header("Fired Item")] 
    public GameObject firedItemSpawn;
    public GameObject firedItemPrefab;
    public float firedItemRate = 5f;
    public float launchForce = 5f;
    public bool usedFiredItem;
    private float nextFiredItem = 0f;
    
    
    [SerializeField] private Image imageCooldownFiredItem;
    private float cooldownTimeFiredItem;
    private float cooldownTimerFiredItem = 0f;
    
    [SerializeField] private Image imageCooldownSpike;
    private float cooldownTimeSpike;
    private float cooldownTimerSpike = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        imageCooldownFiredItem = GameObject.FindWithTag("SkillOne").GetComponent<Image>();
        imageCooldownSpike = GameObject.FindWithTag("SkillTwo").GetComponent<Image>();
        
        
        
        imageCooldownFiredItem.fillAmount = 0f;
        imageCooldownSpike.fillAmount = 0f;

        cooldownTimeFiredItem = firedItemRate;
        cooldownTimeSpike = fireRate;
    }

    void Update()
    {
        if (usedFiredItem)
        {
            ApplyCoolDownFiredItem();
        }
        
        if (usedSpike)
        {
            ApplyCoolDownSpike();
        }
        
        if (Input.GetKeyDown(KeyCode.S) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            SpikeSpawner();
        }
        
        if (Input.GetKeyDown(KeyCode.P) && Time.time > nextFiredItem)
        {
            nextFiredItem = Time.time + firedItemRate;
            FiredItemThrow();
        }

    }

   
    void FixedUpdate()
    {
        HandleMovement();
    }
    private void HandleMovement() 
    {
        // if(PlayerInputHandler.playerCount == 2 && Input.GetKey(KeyCode.Space))
        // {
        //     rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        //     
        // }
        rb.velocity = new Vector2(+moveSpeed, rb.velocity.y);
        anim.SetFloat("velocityX", rb.velocity.x);
    }

    
    public void FiredItemThrow()
    {
        if (usedFiredItem)
        {
            //player has used already the skill
        }
        else
        {
            usedFiredItem = true;
            cooldownTimerFiredItem = cooldownTimeFiredItem;
            GameObject firedItem = Instantiate(firedItemPrefab, firedItemSpawn.transform.position, firedItemSpawn.transform.rotation);
            Rigidbody2D firedItemRb = firedItem.GetComponent<Rigidbody2D>();
            firedItemRb.velocity = -transform.right * launchForce;
        }
        


    }
    
    public void SpikeSpawner()
    {
        if (usedSpike)
        {
            //player has used already the skill
        }
        else
        {
            usedSpike = true;
            cooldownTimerSpike = cooldownTimeSpike;
            GameObject spike = Instantiate(spikeprefab, spikeSpawn.transform.position, spikeSpawn.transform.rotation);
        }
    }
    
    private void ApplyCoolDownFiredItem()
    {
        cooldownTimerFiredItem -= Time.deltaTime;

        if (cooldownTimerFiredItem < 0f)
        {
            usedFiredItem = false;
            imageCooldownFiredItem.fillAmount = 0;
        }
        else
        {
            imageCooldownFiredItem.fillAmount = cooldownTimerFiredItem / cooldownTimeFiredItem;
        }
    }
    
    private void ApplyCoolDownSpike()
    {
        cooldownTimerSpike -= Time.deltaTime;

        if (cooldownTimerSpike < 0f)
        {
            usedFiredItem = false;
            imageCooldownSpike.fillAmount = 0;
        }
        else
        {
            imageCooldownSpike.fillAmount = cooldownTimerSpike / cooldownTimeSpike;
        }
    }

}
