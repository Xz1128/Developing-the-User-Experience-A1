using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float stepDistance = 1f; 

    public void MoveUp()
    {
        transform.position += new Vector3(0, 0, stepDistance);
    }

    public void MoveDown()
    {
        transform.position += new Vector3(0, 0, -stepDistance);
    }

    public void MoveLeft()
    {
        transform.position += new Vector3(-stepDistance, 0, 0);
    }

    public void MoveRight()
    {
        transform.position += new Vector3(stepDistance, 0, 0);
    }
}