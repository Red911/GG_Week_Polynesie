using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    private InputDevice playerInput;

    [SerializeField] private InputAction playerOneJoinAction;
    [SerializeField] private InputAction playerTwoJoinAction;
    private InputDevice keyboard;
    private InputDevice keyboardTwo;

    private void Awake()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
        keyboard = InputSystem.devices.First(i => i.name == "Keyboard");
        keyboardTwo = InputSystem.devices.First(i => i.name == "Keyboard");
        playerOneJoinAction.Enable();
        playerTwoJoinAction.Enable();

    }

    void OnEnable()
    {
        playerOneJoinAction.performed += (e) => JoinPlayer(0, "Player", keyboard);
        playerTwoJoinAction.performed += (e) => JoinPlayer(1, "Thief", keyboardTwo);
    }

    void OnDisable()
    {
        playerOneJoinAction.performed -= (e) => JoinPlayer(0, "Player", keyboard);
        playerTwoJoinAction.performed -= (e) => JoinPlayer(1, "Thief", keyboardTwo);
    }

    private void JoinPlayer(int id, string name, InputDevice device)
    {
        playerInputManager.JoinPlayer(id, -1, name, device);
    }
}
