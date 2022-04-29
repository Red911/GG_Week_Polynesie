using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    playerzer player;
    private static Player players;
    private ThiefPlayer thief;
    public static int playerCount = 0;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();

    public Player Players => players;
    
    void Start()
    {
        if (playerCount < 2)
        {
            players = GameObject.Instantiate(prefabs[playerCount++], transform.position, transform.rotation).GetComponent<Player>();
        }
        
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
        if(players && context.started)
        {
            players.Shooter();
        }
    }
    
    public void FiredItem(InputAction.CallbackContext context)
    {
        if(players && context.started)
        {
            thief.FiredItemThrow();
        }
    }
    
    public void Spike(InputAction.CallbackContext context)
    {
        if(players && context.started)
        {
            thief.SpikeSpawner();
        }
    }
    
}
