using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class TestInput : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector3 inputVector;

    //public delegate void StartTouchEvent(Vector2 position, float time);
    //public event StartTouchEvent OnStartTouch;
    //public delegate void EndTouchEvent(Vector2 position, float time);
    //public event EndTouchEvent OnEndTouch;

    void Start()
    {
        
    }

    void Update()
    {
        //OnMovement();
    }

    public void OnMovement(CallbackContext ctx)
    {
        inputVector = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y, 0);
        transform.position += inputVector * speed;
        Debug.Log(ctx.ReadValue<Vector2>());
    }
}
