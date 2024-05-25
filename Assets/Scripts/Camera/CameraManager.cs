using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance;

    [SerializeField] 
    private CinemachineVirtualCamera[] allVirtualCameras;
    private CinemachineVirtualCamera currentCamera;
    private CinemachineFramingTransposer framingTransposer;


    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
        }

        for (int i = 0; i < allVirtualCameras.Length ; i++)
        {
            if(allVirtualCameras[i].enabled)
            {
                currentCamera = allVirtualCameras[i];
                framingTransposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            }
        }
    }

    public void SwapCamera(CinemachineVirtualCamera cameraFromLeft, CinemachineVirtualCamera cameraFromRight, Vector2 triggerExitDirection)
    {
        if(currentCamera == cameraFromLeft && triggerExitDirection.x > 0f)
        {
            cameraFromRight.enabled = true;
            cameraFromLeft.enabled = false;
            currentCamera= cameraFromRight;
            framingTransposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }
        else if(currentCamera == cameraFromRight && triggerExitDirection.x < 0f)
        {
            cameraFromLeft.enabled = true;
            cameraFromRight.enabled = false;
            currentCamera= cameraFromLeft;
            framingTransposer = currentCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        }

    }
}
