using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 moveDirection;
    private Animator animator;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunAnimation();
        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            WalkAnimation();
        }
        else
        {
            IdleAnimation();
        }
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
      
        moveDirection = (forwardInput * forward) + (rightInput * right);
        moveDirection.Normalize();
        moveDirection.y = 0;
        print(moveDirection);
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
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