using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMouseLook : MonoBehaviour
{
    // Add it inside of main camera
    [Range(50, 500)]
    [SerializeField] private float sensitivity; // 220

    float xRot;
    [SerializeField] private Transform playerBody;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float rotX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        xRot -= rotY;

        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerBody.Rotate(Vector3.up * rotX);
    }

}
