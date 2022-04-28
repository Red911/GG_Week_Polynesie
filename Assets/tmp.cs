using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class tmp : MonoBehaviour
{
    [SerializeField] InputActionReference _input;

    public event Action<int> OnDamage;

    private void Start()
    {
        _input.action.started += Coucou;
    }

    private void OnDestroy()
    {
        _input.action.started -= Coucou;
    }

    private void Coucou(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }
}
