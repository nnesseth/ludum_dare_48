using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float minCameraAngle = -40.0f;
    public float maxCameraAngle = -25.0f;
    public float lookAngle = -35.0f;

    void Update()
    {
        Camera cam = GetComponent<Camera>();

        //Adjust camera when looking up and down
        lookAngle += Input.GetAxis("Mouse Y");
        lookAngle = Mathf.Clamp(lookAngle, minCameraAngle, maxCameraAngle);
        cam.transform.rotation = Quaternion.Euler(-lookAngle, cam.transform.rotation.eulerAngles.y, cam.transform.rotation.eulerAngles.z);
    }
}
