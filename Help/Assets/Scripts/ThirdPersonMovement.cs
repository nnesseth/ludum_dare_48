using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float rotateSpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        // Rotate around the y axis
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Move forward and backward
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float currentSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * currentSpeed);
    }
}
