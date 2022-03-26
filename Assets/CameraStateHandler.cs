using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateHandler : MonoBehaviour
{
    public static Action<CameraStates> CamStateChanged_Event;

    static CameraStates camState;

    public void BootGame()
    {
        camState = CameraStates.TopDown;
    }

    public void SetState(CameraStates _camState)
    {
        camState = _camState;
        CamStateChanged_Event?.Invoke(camState);
    }

    public static CameraStates GetState()
    {
        return camState;
    }


}

public enum CameraStates
{
    TopDown,
    ThirdPerson,
    Boss,
    Tutorial,
    Cutscene
}
