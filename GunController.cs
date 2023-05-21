using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    public Camera mainCamera;
    public Transform gunPivot;

    public Vector3 targetRotation;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            targetRotation = mainCamera.transform.forward;
        }

        gunPivot.rotation = Quaternion.LookRotation(targetRotation);
    }
}
