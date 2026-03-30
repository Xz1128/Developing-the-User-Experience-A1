using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3D : MonoBehaviour
{
    [Tooltip("The rotation angle (in degrees) for each click")]
    public float rotateAngle = 45f;

    
    public void RotateOnce()
    {
        
        transform.Rotate(Vector3.up, rotateAngle, Space.Self);
    }
}
