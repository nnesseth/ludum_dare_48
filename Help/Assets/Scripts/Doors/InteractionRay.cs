using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRay : MonoBehaviour
{
    // Reference to the camera
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Shoot a ray from the mouse position
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // Store info on what was hit
            RaycastHit hit;

            // Cast out the ray: shoot 'ray', store info output in 'hit' 
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Ray cast hit the object: " + hit.collider.name + "\nHit point location: " + hit.point);
            }
        }
    }
}
