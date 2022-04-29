using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour

{
    [Header("Dieu")] 
    public SpriteRenderer FlameGodSprite;
    public SpriteRenderer RainGodSprite;
    public Sprite FlameGodShiningSprite;
    public Sprite RainGodShiningSprite;
    private Sprite originalFlame;
    private Sprite originalRain;

    [Header("Turret")]
    public float Range;
    //la postion du joeur

    public Transform Target;


    bool Detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;


    public GameObject Gun;

    public GameObject Bulette;
    public GameObject Bulette2;

    public float FireRate;

    float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;

    void Start()
    {
        originalFlame = FlameGodSprite.sprite;
        originalRain = RainGodSprite.sprite;
    }
    void Update()
    {
        if (Target != null)
        {
            Vector2 targetPos = Target.position;
            //Direction = la difference entrre la postion de la cible et de la tourelle
            Direction = targetPos - (Vector2)transform.position;
        }

        if(Detected)
        {
            //transform.up tien en compte la rotation c pk le gun va pouvoir tourné sans changer sa positioon en X
            Gun.transform.up = Direction;
            //verifie si le tire est reelement superieur au prochain tire
            if(Time.time > nextTimeToFire && Input.GetKey(KeyCode.F))
            {
                //la en gros on divise par 1 ou plus si le tire est est supperieur a Time.time
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot(); 
                
            }
            if (Time.time > nextTimeToFire && Input.GetKey(KeyCode.H))
            {
                //la en gros on divise par 1 ou plus si le tire est est supperieur a Time.time
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot2();
                
            }
        }
    }

    bool IsTrap(Collider2D c) => c.gameObject.tag == "trapFire" || c.gameObject.tag == "trapWater";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsTrap(collision))
        {
            Target = collision.transform;
            if (Detected == false)
            {
                Detected = true;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsTrap(collision))
        {
            Target = null;
            if (Detected == true)
            {
                Detected = false;
                AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
       
    }

    void shoot()
    {
      GameObject BulletteIns = Instantiate(Bulette, ShootPoint.position, Quaternion.identity);
        BulletteIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        FlameGodSprite.sprite = FlameGodShiningSprite;
        Invoke("OriginalFlameSprite", 3f);
    }

    void shoot2()
    {
        GameObject BulletteIns = Instantiate(Bulette2, ShootPoint.position, Quaternion.identity);
        BulletteIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        RainGodSprite.sprite = RainGodShiningSprite;
        Invoke("OriginalRainSprite", 3f);
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void OriginalFlameSprite()
    {
        FlameGodSprite.sprite = originalFlame;
    }
    
    private void OriginalRainSprite()
    {
        RainGodSprite.sprite = originalRain;
    }
}
