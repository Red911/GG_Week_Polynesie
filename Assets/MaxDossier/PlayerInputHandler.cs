using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    playerzer player;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    void Start()
    {
        player = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position, transform.rotation).GetComponent<playerzer>();
    }


    public void Move(InputAction.CallbackContext context)
    {
       if(player)
        {
            player.Move(context.ReadValue<Vector2>());
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(player && context.started)
        {
            player.Shoot();
        }
    }
    // Update is called ozence per frame
    void Update()
    {
        
    }
}
