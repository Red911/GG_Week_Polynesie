using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float depth = 1;

    private PlayerBehaviour player;
    
    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float realvelocity = player.velocity.x / depth;
        Vector2 pos = transform.position;

        pos.x -= realvelocity * Time.fixedDeltaTime;

        if (pos.x <= -15)
            pos.x = 15;

        transform.position = pos;
    }
}
