using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    Rigidbody rb;

    bool cameraOn;
    float rotationOnX;

    float inputX, inputY;
    float mouseX;

    [SerializeField] float mouseSensitivity = 90;
    [SerializeField] float cameraVelocity = 10;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!cameraOn)
            {
                cameraOn = true;

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (cameraOn)
            {
                cameraOn = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }


        if (cameraOn)
        {
            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;
            mouseX += Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

            rotationOnX -= mouseY;
            rotationOnX = Mathf.Clamp(rotationOnX, -90, 90);
            transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);

            inputX = Input.GetAxis("Horizontal") * cameraVelocity;
            inputY = Input.GetAxis("Vertical") * cameraVelocity;

            rb.velocity = new Vector3(inputX * Time.deltaTime, 0.0f, inputY * Time.deltaTime);
        }
    }
}
