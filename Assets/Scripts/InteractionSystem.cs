using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{

    public GameObject focusedObject;

    public GameObject pickUpSlot;

    public float interactDistance;

    public bool holding;

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
    private void FixedUpdate()
    {
        if (holding)
            return;

        // Compute the player's forward direction
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        // Craete hit variable to store our results
        RaycastHit hit;

        // Ray originating from the camera
        Ray ray = new Ray(transform.position, fwd);

        // Conduct the raycast
        if(Physics.Raycast(ray, out hit))
        {
            focusedObject = hit.collider.gameObject;
        }
        else
        {
            focusedObject = null;
        }
    }

    public void OnInteract()
    {
        if (holding)
        {
            // Drop what we're holding
            focusedObject.transform.parent = null;
            focusedObject.GetComponent<Rigidbody>().isKinematic = false;
            holding = false;
        }
        else if (focusedObject.CompareTag("Interactable"))
        {
            // Pick the barrel up
            focusedObject.transform.parent = pickUpSlot.transform;
            focusedObject.transform.position = pickUpSlot.transform.position;
            focusedObject.GetComponent<Rigidbody>().isKinematic = true;
            holding = true;
        }
    }
    

}
