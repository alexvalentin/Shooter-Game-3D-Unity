using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    public Transform player;
    public float mouseSensitivity = 2f;
    float cameraVerticalRotation = 0f;


    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // rotate camera around its local X axis
        //cameraVerticalRotation -= inputY;
        //cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);

        // rotate the player object
        player.Rotate(Vector3.up * inputX);
       
    }
}
