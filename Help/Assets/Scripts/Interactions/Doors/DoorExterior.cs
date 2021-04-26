using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExterior : MonoBehaviour
{
    private Animator doorSwing;

    private bool doorOpen = false;



    /*
    bool doorIsClosed = true;
    bool playerAtDoor = false;
    float minDistance = 5f;*/
    private void Start()
    {
        doorSwing = GetComponent<Animator>();
    }


    public void DoorAnimation()
    {
        if (!doorOpen)
        {
            doorSwing.Play("Door(Exterior)Opening", 0, 0f);
            doorOpen = true;

        }
        else
        {
            doorSwing.Play("Door(Exterior)Closing", 0, 0f);
            doorOpen = false;
        }
    }
}

