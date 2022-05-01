using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : PersistentSingleton<InputManager>
{
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouch;

    Vector2 touchPosition;
    public Vector2 TouchPosition { get => touchPosition; }

    private TouchControls touchControls;

    internal override void Awake()
    {
        touchControls = new TouchControls();
        EnhancedTouchSupport.Enable();

    }

    private void OnEnable()
    {
        touchControls.Enable();
        TouchSimulation.Enable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        touchControls.Disable();
        TouchSimulation.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
        EnhancedTouchSupport.Disable();
    }

    private void FingerDown(Finger obj)
    {
        if (OnStartTouch != null) OnStartTouch(obj.screenPosition, Time.time);
    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext ctx)
    {
        if (OnStartTouch != null) OnStartTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)ctx.startTime);
    }

    private void EndTouch(InputAction.CallbackContext ctx)
    {
        if (OnEndTouch != null) OnEndTouch(touchControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)ctx.time);
    }

    private void Update()
    {
        touchPosition = touchControls.Touch.TouchPosition.ReadValue<Vector2>();
    }

    public Vector2 GetTouchPosition()
    {
        return touchPosition;
    }

}
