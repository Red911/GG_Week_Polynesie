using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScript : MonoBehaviour
{
 
    CameraFollow cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            cam.player.GetComponent<Player>().moveSpeed -= 1;
            Debug.Log("ta perdu dla vie");
        }

        Destroy(this.gameObject);
    }

    

}
