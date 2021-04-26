using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRay : MonoBehaviour
{
    // Reference to the camera
    Camera cam;
    Interactable interactableObject;
    StatusEffects status;

    private const string interactableTag = "Interactable Object";
    
    
    public GameObject lastHit; // important
    [SerializeField] private int rayLength = 10;


    public Vector3 collision = Vector3.zero;


    private DoorExterior hitExtDoor;
    private DoorInterior hitIntDoor;

    private Renderer sheetsUnmade;
    private Renderer pillowUnmade;
    private Renderer sheetsMade;
    private Renderer pillowMade;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
        sheetsMade = GameObject.Find("Bed Blanket - Made").GetComponent<Renderer>();
        sheetsMade.enabled = false;
        sheetsUnmade = GameObject.Find("Bed Blanket - Unmade").GetComponent<Renderer>();
        sheetsUnmade.enabled = true;
        pillowMade = GameObject.Find("Bed Pillow - Made").GetComponent<Renderer>();
        pillowMade.enabled = false;
        pillowUnmade = GameObject.Find("Bed Pillow - Unmade").GetComponent<Renderer>();
        pillowUnmade.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //interactableObject = GameObject.Find("");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);           // Shoot a ray from the mouse position
            RaycastHit hit;                                                // Store info on what was hit

            if (Physics.Raycast(ray, out hit, rayLength))                  // Check if the ray physically hits
            {

                // Ray hitting debugger
                //Debug.Log("Ray cast hit the object: " + hit.collider.name + "\nHit point location: " + hit.point);


                // If hit collider name is an object with an interactable script on it, then call that script to do things
                if (hit.collider.CompareTag(interactableTag))
                {
                    lastHit = hit.transform.gameObject; // can be useful somehow if you learn to use Interactable.cs
                    //collision = hit.point;            // this and next line may also be useful
                    //interactableObject.Interacted(lastHit, collision);

                    // Debugger
                    Debug.Log("Hit an INTERACTABLE tagged object: " + hit.collider.name);

                    if (hit.collider.name == "Door (Ext) Swinger" && status.isBedMade && status.amIFed && status.areTeethBrushed && status.doIhaveWallet && status.doIhaveKeys)
                    {
                        hitExtDoor = hit.collider.gameObject.GetComponent<DoorExterior>();
                        hitExtDoor.DoorAnimation();
                    } else if (hit.collider.name == "Door (Int) Swinger")
                    {
                        hitIntDoor = hit.collider.gameObject.GetComponent<DoorInterior>();
                        hitIntDoor.DoorAnimation();
                    } else if(hit.collider.name == "Bed Blanket - Unmade")
                    {
                        sheetsMade.enabled = true;
                        pillowMade.enabled = true;
                        sheetsUnmade.enabled = false;
                        pillowUnmade.enabled = false;
                    } else
                    {
                        Debug.Log("*** Missing interaction script for an interactable tagged object! ***");
                    }




                }

            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(collision, 0.25f);
    }
}
