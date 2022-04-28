using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletScriptWater : MonoBehaviour
{
    public int addSpeed = 1;
    public int RemoveSpeed = 1;
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
        if (collision.gameObject.tag == "trapWater")
        {
            cam.player.GetComponent<Player>().moveSpeed += addSpeed;
            Debug.Log("ta gagner dla vie");
       
        }
        else
        {
            cam.player.GetComponent<Player>().moveSpeed -= RemoveSpeed;
            Debug.Log("ta perdu dla vie");
        
        }

        Destroy(this.gameObject);

    }



}
