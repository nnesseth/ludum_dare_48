using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExterior : MonoBehaviour
{
    private bool doorIsClosed = true;
    private bool playerAtDoor = false;
    private int minDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Get player location
        playerAtDoor = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if player is close to the door, then allow player to cast a ray

        // if raycast hits door, and if door is closed, then open door

        // else close the door
    }
}
