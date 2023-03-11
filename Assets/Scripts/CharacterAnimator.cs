using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator animator;
    CharacterController controller;
    const float locomotionAnimationSmoothTime = .1f;
    ThirdPersonMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        playerMovement = GameObject.Find("Player").GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get current non-vertical velocity of player
        Vector3 playerVelocity = controller.velocity;
        playerVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.y);

        float playerCurrentVelocity = playerVelocity.magnitude;

        float playerTakeOffSpeed = playerCurrentVelocity;

        //playerMovement.getSpeed();

        animator.SetFloat("playerTakeOffSpeed", playerTakeOffSpeed, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
