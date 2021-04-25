using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteraction : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] private StatusEffects status;

    void Start(){
        status = GameObject.Find("Player").GetComponent<StatusEffects>();
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
