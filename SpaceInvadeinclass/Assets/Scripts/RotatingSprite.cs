using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingSprite : MonoBehaviour
{
    public float rotationSpeed = 20f;
    
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

