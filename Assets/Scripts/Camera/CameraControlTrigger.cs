using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraControlTrigger : MonoBehaviour
{
    private Collider2D collider2D;
    public bool swapCameras = false;
    public CinemachineVirtualCamera cameraOnLeft;
    public CinemachineVirtualCamera cameraOnRight;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();

    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        Vector2 exitDirection = (collision.transform.position - collider2D.bounds.center).normalized;
        if(collision.CompareTag("Player"))
        {
            if(swapCameras && cameraOnLeft != null && cameraOnRight != null)
            {
                CameraManager.instance.SwapCamera(cameraOnLeft, cameraOnRight, exitDirection);
            }
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision) 
    {
        Vector2 exitDirection = (collision.transform.position - collider2D.bounds.center).normalized;
        if(collision.CompareTag("Player"))
        {
            if(swapCameras && cameraOnLeft != null && cameraOnRight != null)
            {
                CameraManager.instance.SwapCamera(cameraOnLeft, cameraOnRight, exitDirection);
            }
        }
    }*/
}

