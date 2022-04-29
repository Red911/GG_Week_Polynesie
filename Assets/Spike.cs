using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * 3f);

        if (hit.collider.tag == "Player")
        {
            cam.player.GetComponent<Player>().moveSpeed += addSpeed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawRay(transform.position, Vector2.up * 3f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
     
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            cam.player.GetComponent<Player>().moveSpeed -= RemoveSpeed;

        }
    }
}
