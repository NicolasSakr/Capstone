using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotX = 0.0f;
    private float rotY = 0.0f;

    public Transform playerBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotX -= mouseY;
        rotY += mouseX;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localCameraRotation = Quaternion.Euler(rotX, 0.0f, 0.0f);
        transform.localRotation = localCameraRotation;

        Quaternion localPlayerRotation = Quaternion.Euler(0.0f, rotY, 0.0f);
        playerBody.localRotation = localPlayerRotation;

        // Apply the same rotation to the player's transform
        playerBody.Rotate(Vector3.up * mouseX);
    }
}