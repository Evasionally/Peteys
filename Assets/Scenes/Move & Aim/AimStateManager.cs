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

    public float rotationSpeed = .9f;

    private void FixedUpdate()
    {
        Boolean rightClickHeld = Input.GetMouseButton(1);
        
        aimCamera.gameObject.SetActive(rightClickHeld);
        thirdPersonCam.gameObject.SetActive(!rightClickHeld);

        if (rightClickHeld)
        {
            float targetAngle = mainCam.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
