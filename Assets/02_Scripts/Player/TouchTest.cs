using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTest : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Awake()
    {
        inputManager = InputManager.Instance;
        cameraMain = Camera.main;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += Move;
    }

    private void Update()
    {
        Move(inputManager.TouchPosition);
    }

    private void OnDisable()
    {
        inputManager.OnEndTouch -= Move;

    }

    private void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;

    }

    //private IEnumerator MoveTowardsPosition(Vector3 _position)
    //{
    //    yield 
    //}

    private void MoveTowards(Vector3 _position)
    {
        transform.position = Vector3.MoveTowards(transform.position, _position, speed);
    }

    private void TopDownMovement(Vector2 screenPosition)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, 0);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        MoveTowards(worldCoordinates);
    }


    private void Move(Vector2 screenPosition)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x, screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinates = cameraMain.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        transform.position = worldCoordinates;

    }
}
