using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    // Defining Camera and naming it player camera 
    public Camera playerCamera;

    // Container variables for the mouse delta values of each frame
    public float deltaX;
    public float deltaY;

    // Container variables for the player's rotation X and Y axis of each frame
    public float xRot;
    public float yRot;


    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yRot += deltaX;
        xRot -= deltaY;

        // Keep the player's rotation clamped to [-90, 90] degrees
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Rotate the camera around the x-axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    // OnCameraLook event handler
    public void OnCameraLook(InputValue value)
    {
        // Reading the mouse deltas
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
