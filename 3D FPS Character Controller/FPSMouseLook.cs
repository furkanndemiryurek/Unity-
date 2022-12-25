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

    public Transform leaner;
    public float zRot;
    bool isRotating;

    private void Start()
    {
        Cursor.visible = false;
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
        Leaner();

    }

    public void Leaner()
    {
        if (Input.GetKey(KeyCode.E))
        {
            zRot = Mathf.Lerp(zRot, -20.0f, 5f * Time.deltaTime);
            isRotating = true;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            zRot = Mathf.Lerp(zRot, 20.0f, 5f * Time.deltaTime);
            isRotating = true;
        }

        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.Q))
        {
            isRotating = false;
        }

        if (!isRotating)
        {
            zRot = Mathf.Lerp(zRot, 0, 5f * Time.deltaTime);
        }

        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
    }

}
