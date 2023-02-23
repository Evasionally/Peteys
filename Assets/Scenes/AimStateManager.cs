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
    private void Update()
    {
        aimCamera.gameObject.SetActive(Input.GetMouseButton(1));
        thirdPersonCam.gameObject.SetActive(!Input.GetMouseButton(1));
    }
}
