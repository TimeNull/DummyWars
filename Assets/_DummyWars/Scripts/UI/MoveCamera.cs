using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public static bool cameraOn;


    private void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            if (!cameraOn)
            {
                cameraOn = true;

                GetComponent<SimpleCameraController>().enabled = true;
            }
            else if (cameraOn)
            {
                cameraOn = false;

                GetComponent<SimpleCameraController>().enabled = false;
            }
        }

    }
}
