using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;

    float sensitivity = 4;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 *  sensitivity;

        rotationX = Mathf.Clamp(rotationX, -45, 45);


        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }



}
