using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utility : MonoBehaviour
{
    /// <summary>
    /// Make an object look at another with delay.
    /// </summary>
    /// <param name="to"></param>
    public static void RotateTowards(Transform ownObject, Vector3 to, float turnSpeed, bool ignoreY)
    {
        if(ignoreY)
            to = Vector3.ProjectOnPlane(to, Vector3.up); //removes the x and z rotation

        Quaternion _lookRotation = Quaternion.LookRotation((to - ownObject.position).normalized);

        ownObject.rotation = Quaternion.Slerp(ownObject.rotation, _lookRotation, Time.deltaTime * turnSpeed);
    }
}
