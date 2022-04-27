using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    playerzer player;
    private Player players;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    void Start()
    {
        players = GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Count)], transform.position, transform.rotation).GetComponent<Player>();
    }


    public void Jump(InputAction.CallbackContext context)
    {
       if(players)
        {
            players.Jump(context.ReadValue<float>());
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(player && context.started)
        {
            players.Shooter();
        }
    }
    
}
