using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private StatusEffects status;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float rotateSpeed = 3.0f;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Get current non-vertical velocity of player
        Vector3 playerVelocity = controller.velocity;
        playerVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.y);

        // Rotate around the y axis
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        //WASD Movement with a character controller
        Vector3 movement = Vector3.zero;
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        movement += transform.forward * v * speed * status.getEnergy() * Time.deltaTime;
        movement += transform.right * h * speed * status.getEnergy() * Time.deltaTime;
        movement += Physics.gravity;
        controller.Move(movement);
    }

    public float getSpeed()
    {
        return speed;
    }
}
