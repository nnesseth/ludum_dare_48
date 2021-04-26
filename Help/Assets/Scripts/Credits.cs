using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    void Update() {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            Application.Quit();
            Debug.Log("Application quit.");
        }
    }
}
