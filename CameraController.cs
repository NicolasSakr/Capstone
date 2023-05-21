using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float maxAngle = 60f; // Maximum rotation angle on the X axis
    private Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.localRotation; // Save the original rotation of the GameObject
    }

    void Update()
    {
        // Get the current rotation of the GameObject
        Quaternion currentRotation = transform.localRotation;

        // Calculate the X angle of the current rotation using Euler angles
        float xAngle = currentRotation.eulerAngles.x;

        // If the X angle is greater than the maximum angle, clamp it to the maximum angle
        if (xAngle > 180f)
        {
            xAngle -= 360f;
        }
        xAngle = Mathf.Clamp(xAngle, -maxAngle, maxAngle);

        // Apply the clamped X angle to the current rotation
        Quaternion newRotation = Quaternion.Euler(xAngle, currentRotation.eulerAngles.y, currentRotation.eulerAngles.z);

        // Set the new rotation of the GameObject
        transform.localRotation = newRotation;
    }
}

