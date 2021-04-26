using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{/*
    public float playerRadius = 5f;
    public Transform player;
    public Transform interactionTransform;
    bool hasInteracted = false;

    // The virtual method allows all interactable items to derive from the same method
    // BUT the type of interaction can be different for each item: ex. complete a task, open a door, etc.
    public virtual void Interact()
    {
        // ** This method is meant to be overwritten by specific item interaction scripts ** 
        //Debug.Log("Interacted with " + transform.name);
    }

    private void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
/*    void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        

        if (distance <= playerRadius)
        {
            hasInteracted = false;

            if (!hasInteracted)
            {
                Interact();
                hasInteracted = true;
            }
        }

    }

    public void Interacted ()
    {
        //
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(player.position, playerRadius);
    }
*/}


