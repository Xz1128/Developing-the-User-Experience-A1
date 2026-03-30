using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBoy : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialScale = transform.localScale;
    }

    
    public void ResetAll()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        transform.localScale = initialScale;
    }
}