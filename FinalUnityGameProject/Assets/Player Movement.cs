using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationSpeed = 8f; // Controls smoothness of rotation
    [SerializeField] private Vector3 moveDirection;
    [SerializeField] private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        // Fix: Swap forward and right inputs and negate the right input for correct rotation
        moveDirection = new Vector3(rightInput, 0, -forwardInput); 

        if (moveDirection == Vector3.zero)
        {
            animator.SetFloat("Speed", 0);
        }
        else if (!Input.GetKey(KeyCode.W))
        {
            animator.SetFloat("Speed", 0.5f);
        }
        else
        {
            animator.SetFloat("Speed", 1);
        }

        moveDirection *= speed;

        // Rotation fix with proper direction
        if ((moveDirection.x != 0) || (moveDirection.z != 0))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * rotationSpeed);
        }

        characterController.Move(moveDirection * Time.deltaTime);
    }
}