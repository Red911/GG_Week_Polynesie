using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    private InputDevice playerInput;
    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    void Update()
    {
        var keyboard = InputSystem.devices.First(i => i.name == "Keyboard");
        var gamepad = InputSystem.devices.First(i => i.name == "XInputControllerWindows");
        if (Input.GetKey(KeyCode.P))
        {  
            playerInputManager.JoinPlayer(0, -1, null, keyboard);
        }
    }
}
