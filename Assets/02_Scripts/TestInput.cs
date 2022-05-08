using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class TestInput : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector3 inputVector;

    void Start()
    {
        
    }

    void Update()
    {
        //OnMovement();
        transform.position += inputVector * speed * Time.deltaTime;
    }

    public void OnMovement(CallbackContext ctx)
    {
        inputVector = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y, 0);
        Debug.Log(ctx.ReadValue<Vector2>());
    }
}
