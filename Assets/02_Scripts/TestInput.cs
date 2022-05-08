using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class TestInput : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnMovement(CallbackContext ctx)
    {
        Debug.Log(ctx.ReadValue<Vector2>());
    }
}
