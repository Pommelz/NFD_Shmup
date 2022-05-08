using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class MovementController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    Vector3 inputVector;
    Vector3 movementVector;
    CameraStates currentState;

    private void OnEnable()
    {
        CameraStateHandler.CamStateChanged_Event += OnCamStateChanged;
    }
    private void OnDisable()
    {
        CameraStateHandler.CamStateChanged_Event -= OnCamStateChanged;
    }

    private void OnCamStateChanged(CameraStates state)
    {
        currentState = state;
    }

    void Update()
    {
        MovementVectorByCameraState();
        transform.position += movementVector * speed * Time.deltaTime;
    }

    private void MovementVectorByCameraState()
    {
        switch (currentState)
        {
            case CameraStates.TopDown:
                movementVector = inputVector;
                break;
            case CameraStates.ThirdPerson:
                movementVector = new Vector3(inputVector.x, 0, 0);
                break;
            case CameraStates.SideScroller:
                break;
            case CameraStates.Boss:
                break;
            case CameraStates.Tutorial:
                break;
            case CameraStates.Cutscene:
                break;
        }
    }
    
    public void OnMovement(CallbackContext ctx)
    {
        inputVector = new Vector3(ctx.ReadValue<Vector2>().x, ctx.ReadValue<Vector2>().y, 0);
        Debug.Log(ctx.ReadValue<Vector2>());
    }
}