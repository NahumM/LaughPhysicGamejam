using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // Camera movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Camera rotation
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Rotate the camera based on mouse input
        transform.Rotate(Vector3.up, mouseX * rotationSpeed);
        transform.Rotate(Vector3.left, mouseY * rotationSpeed);

        // Limit vertical rotation to avoid flipping the camera
        float currentXRotation = transform.rotation.eulerAngles.x;
        if (currentXRotation > 80f && currentXRotation < 180f)
        {
            currentXRotation = 80f;
        }
        else if (currentXRotation > 180f && currentXRotation < 280f)
        {
            currentXRotation = 280f;
        }

        transform.rotation = Quaternion.Euler(currentXRotation, transform.rotation.eulerAngles.y, 0f);
    }
}
