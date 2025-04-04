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
    }
    void MovementHandler()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput > 0) 
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0f; 
            forward.Normalize();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentSpeed = runSpeed;
                RunAnimation();
            }
            else
            {
                currentSpeed = walkSpeed;
                WalkAnimation();
            }
            moveDirection = forward * verticalInput;
            characterController.Move(moveDirection * currentSpeed * Time.deltaTime);

            if (moveDirection.magnitude > 0)
            {
                transform.rotation = Quaternion.LookRotation(forward);
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
