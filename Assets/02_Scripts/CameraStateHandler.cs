using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStateHandler : MonoBehaviour
{
    public static Action<CameraStates> CamStateChanged_Event;
    [SerializeField] static Camera topDownCam;
    [SerializeField] static Camera thirdPersonCam;
    [SerializeField] static Camera sideScrollerCam;
    [SerializeField] int cameraCount = 3;
    private Camera activeCamera;
    static CameraStates camState;

    public void StartGame()
    {
        camState = CameraStates.TopDown; //CameraStates _camState
    }

    public void SetState(CameraStates _camState)
    {
        camState = _camState;
        UpdateCamera();
        CamStateChanged_Event?.Invoke(camState);
    }

    public static CameraStates GetState()
    {
        return camState;
    }


    public void UpdateCamera()
    {
        switch (camState)
        {
            case CameraStates.TopDown:
                thirdPersonCam.gameObject.SetActive(false);
                sideScrollerCam.gameObject.SetActive(false);
                topDownCam.gameObject.SetActive(true);
                activeCamera = topDownCam;
                break;
            case CameraStates.ThirdPerson:
                sideScrollerCam.gameObject.SetActive(false);
                topDownCam.gameObject.SetActive(false);
                thirdPersonCam.gameObject.SetActive(true);
                activeCamera = thirdPersonCam;
                break;
            case CameraStates.SideScroller:
                thirdPersonCam.gameObject.SetActive(false);
                topDownCam.gameObject.SetActive(false);
                sideScrollerCam.gameObject.SetActive(true);
                activeCamera = sideScrollerCam;
                break;
            case CameraStates.Boss:
                activeCamera = topDownCam;
                break;
            case CameraStates.Tutorial:
                activeCamera = topDownCam;
                break;
            case CameraStates.Cutscene:
                activeCamera = topDownCam;
                break;
            default:
                activeCamera = topDownCam;
                break;
        }
    }

}

public enum CameraStates
{
    TopDown,
    ThirdPerson,
    SideScroller,
    Boss,
    Tutorial,
    Cutscene
}
