using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    //movement axis and movement distance for computing open and closed positions
    public Vector3 movementAxis;
    public float distance;

    //open and closed positions of this door
    private Vector3 openPos;
    private Vector3 closedPos;

    //the amount of frames the door open animation should take
    public float frames;

    //boolean variable to test if door is closed or not <------ NOT USED; JUST TO TEST
    public bool closedDoor = false;

    private void Start()
    {
        //Assume the door starts closed. how would you fix this if you can't make this assumption?
        //ANS: Make an "if" statement testing whether or not the door was initially closed. If the door was not close, make it closed.

        if (closedPos == new Vector3(0,0,0))
        {
            closedPos = transform.position;
            openPos = closedPos + (movementAxis * distance);
        }

    }

    public void CloseGate()
    {
        //Without Coroutines
        //transform.Translate(movementAxis * distance * -1f, Space.World);

        //Basic Coroutine in Frames
        //StartCoroutine(DoorMove(openPos, closedPos, 1 / frames)); //door glitches out

        //Fix door jump glitch by stopping already running coroutines and startin from current position
        StopAllCoroutines(); //add to stop previously running coroutines
        StartCoroutine(DoorMove(transform.position, closedPos, 1 / (frames + 1) )); //What's the bug here, can you solve it?
    }

    public void OpenGate()
    {
        //Without Coroutines
        //transform.Translate(movementAxis * distance, Space.World);

        //Basic Coroutine in Frames
        //StartCoroutine(DoorMove(closedPos, openPos, 1 / frames)); //door glitches out

        //Fix door jump glitch by stopping already running coroutines and startin from current position
        StopAllCoroutines();
        StartCoroutine(DoorMove(transform.position, openPos, 1 / (frames + 1) )); //What's the bug here, can you solve it?
    }

    public IEnumerator DoorMove(Vector3 startPos, Vector3 endPos, float step)
    {
        for(float i = 0; i <= 1f; i += step)
        {
            Vector3 newPos = Vector3.Lerp(startPos, endPos, i);
            transform.position = newPos;
            yield return null;
        }
    }
}
