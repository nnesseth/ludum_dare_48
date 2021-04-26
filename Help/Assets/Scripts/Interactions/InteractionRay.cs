using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRay : MonoBehaviour
{
    // Reference to the camera
    Camera cam;
    Interactable interactableObject;

    private const string interactableTag = "Interactable Object";
    
    
    public GameObject lastHit; // important
    [SerializeField] private int rayLength = 10;


    public Vector3 collision = Vector3.zero;


    private DoorExterior hitDoor;



    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //interactableObject = GameObject.Find("");

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    // Shoot a ray from the mouse position
            RaycastHit hit;                                         // Store info on what was hit

            if (Physics.Raycast(ray, out hit, rayLength))                  // Check if the ray physically hits
            {

                // Debugger
                Debug.Log("Ray cast hit the object: " + hit.collider.name + "\nHit point location: " + hit.point);






                // If hit collider name is an object with an interactable script on it, then call that script to do things
                if (hit.collider.CompareTag(interactableTag))
                {
                    lastHit = hit.transform.gameObject;

                    //collision = hit.point;
                    //interactableObject.Interacted(lastHit, collision);

                    // Debugger
                    Debug.Log("Hit INTERACTABLE tagged object: " + hit.collider.name);


                    hitDoor = hit.collider.gameObject.GetComponent<DoorExterior>();
                    hitDoor.DoorAnimation();
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
