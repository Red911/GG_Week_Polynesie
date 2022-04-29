using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    playerzer player;
    private static Player players;
    private ThiefPlayer thief;
    private turretScript turret;
    public static int playerCount = 0;

    [SerializeField] List<GameObject> prefabs = new List<GameObject>();
    [SerializeField] private float posDiff = 4;

    public Player Players => players;
    
    void Start()
    {
        if (playerCount < 2)
        {
            players = GameObject.Instantiate(prefabs[playerCount],
                transform.position + Vector3.right * posDiff * playerCount,
                transform.rotation).GetComponent<Player>();
            playerCount++;
        }
        
    }


    public void Jump(InputAction.CallbackContext context)
    {
       if(players)
        {
            players.Jump(context.ReadValue<float>());
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if(players && context.started)
        {
            turret.shoot();
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

    public void Water(InputAction.CallbackContext context)
    {
        if(players && context.started)
        {
            turret.shoot2();
        }
    }
    
}
