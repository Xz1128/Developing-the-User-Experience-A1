using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    [Tooltip("Each scaling factor (greater than 1 for enlargement, less than 1 for reduction)")]
    public float scaleFactor = 1.1f;  

    [Tooltip("Minimum zoom level (to prevent it from being too small)")]
    public float minScale = 0.2f;

    [Tooltip("Maximum zoom level (to prevent it from being too large)")]
    public float maxScale = 3.0f;

    
    public void ScaleUp()
    {
        Vector3 newScale = transform.localScale * scaleFactor;
        
        if (newScale.x <= maxScale && newScale.y <= maxScale && newScale.z <= maxScale)
        {
            transform.localScale = newScale;
        }
        else
        {
            
            transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        }
    }

    
    public void ScaleDown()
    {
        Vector3 newScale = transform.localScale / scaleFactor;
        
        if (newScale.x >= minScale && newScale.y >= minScale && newScale.z >= minScale)
        {
            transform.localScale = newScale;
        }
        else
        {
            transform.localScale = new Vector3(minScale, minScale, minScale);
        }
    }
}
