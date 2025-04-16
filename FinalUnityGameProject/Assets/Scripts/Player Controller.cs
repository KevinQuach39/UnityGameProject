using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    private float currentSpeed;
    private Vector3 moveDirection;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MovementHandler();
        UpdateAnimations();
    }
    void MovementHandler()
    {
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        forward.Normalize();

        moveDirection = forward * verticalInput;

        currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

        if (moveDirection.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(forward);
        }
    }
    void UpdateAnimations()
    {
        Vector3 velocity = characterController.velocity;
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0f, velocity.z);

        bool isMoving = horizontalVelocity.magnitude > 0.1f;
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        if (isMoving)
        {
            if (isRunning)
            {
                RunAnimation();
            }
            else
            {
                WalkAnimation();
            }
        }
        else
        {
            IdleAnimation();
        }
    }
    void WalkAnimation()
    {
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
    }
    void RunAnimation()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
    }
    void IdleAnimation()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
    }
}
