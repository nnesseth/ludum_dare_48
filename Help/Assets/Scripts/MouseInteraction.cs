using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    public Renderer rend;

    void Start(){
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter() {
        Debug.Log("Mouse entered: " + rend.name);
    }

    void OnMouseExit() {
        Debug.Log("Mouse exited: " + rend.name);
    }

    void OnMouseUp() {
        Debug.Log("The " + rend.name + " was clicked");
    }

}
