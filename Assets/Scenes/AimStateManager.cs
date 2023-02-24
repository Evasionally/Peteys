using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class AimStateManager : MonoBehaviour
{
    public CinemachineVirtualCamera aimCamera;
    public CinemachineFreeLook thirdPersonCam;
    public Camera mainCam;
    
    public LayerMask aimColliderMask = new LayerMask();

    public Transform aimPosition;

    private void Update()
    {
        Boolean rightClickHeld = Input.GetMouseButton(1);
        
        aimCamera.gameObject.SetActive(rightClickHeld);
        thirdPersonCam.gameObject.SetActive(!rightClickHeld);

        if (rightClickHeld)
        {
            
        }
    }
}
