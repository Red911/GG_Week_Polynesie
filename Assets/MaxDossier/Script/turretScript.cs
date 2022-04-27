using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretScript : MonoBehaviour

{

    public float Range;
    //la postion du joeur
    public Transform[] Target;


    bool Detected = false;

    Vector2 Direction;

    public GameObject AlarmLight;


    public GameObject Gun;

    public GameObject Bulette;

    public float FireRate;

    float nextTimeToFire = 0;

    public Transform ShootPoint;

    public float Force;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Target.Length; i++)
        {
            Vector2 targetPos = Target[i].position;
            //Direction = la difference entrre la postion de la cible et de la tourelle
            Direction = targetPos - (Vector2)transform.position;
        }
        
       
        //pour capté notre player
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "trap")
            {
                if (Detected == false)
                {
                    Detected = true;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
            else
            {
                if (Detected == true)
                {
                    Detected = false;
                    AlarmLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }

        if(Detected)
        {
            //transform.up tien en compte la rotation c pk le gun va pouvoir tourné sans changer sa positioon en X
            Gun.transform.up = Direction;
            //verifie si le tire est reelement superieur au prochain tire
            if(Time.time > nextTimeToFire)
            {
                //la en gros on divise par 1 ou plus si le tire est est supperieur a Time.time
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    void shoot()
    {
      GameObject BulletteIns = Instantiate(Bulette, ShootPoint.position, Quaternion.identity);
        BulletteIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
