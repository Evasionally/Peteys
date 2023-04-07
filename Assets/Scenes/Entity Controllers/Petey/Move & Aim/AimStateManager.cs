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

    [NonSerialized] public Boolean isAiming;

    private void FixedUpdate()
    {
        isAiming = Input.GetMouseButton(1);
        
        aimCamera.gameObject.SetActive(isAiming);
        thirdPersonCam.gameObject.SetActive(!isAiming);

        if (isAiming)
        {
            float targetAngle = mainCam.transform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
