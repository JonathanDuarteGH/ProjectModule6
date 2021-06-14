using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(direction * speed * Time.deltaTime);

        // Make world direction into local direction
        Vector3 localDirection = transform.TransformDirection(direction);

        // Move with physics
        rb.MovePosition(rb.position + (localDirection * speed * Time.deltaTime));
    }

    // OnPlayerMove event handler
    public void OnPlayerMove(InputValue value)
    {
        // A vector with x and y components corresponding to the players's WASD and arrow inputs; values are in the range [-1, 1]
        Vector2 inputVector = value.Get<Vector2>();

        // direction = new Vector3(inputVector.x, 0, direction.y);

        // Assign directional components to mapreal world character movements
        direction.x = inputVector.x;
        direction.z = inputVector.y;
    }
}
