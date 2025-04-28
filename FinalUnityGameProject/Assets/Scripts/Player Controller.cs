using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform muzzle;
    private float currentSpeed;
    private Vector3 moveDirection;
    private Animator animator;
    private enum MovementState { Idle, Walking, Running }
    private MovementState currentMovementState = MovementState.Idle;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        MovementHandler();
        UpdateAnimations();
        HandleFiring();
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
                currentMovementState = MovementState.Running;
            }
            else
            {
                WalkAnimation();
                currentMovementState = MovementState.Walking;
            }
        }
        else
        {
            IdleAnimation();
            currentMovementState = MovementState.Idle;
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
    void HandleFiring()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayFiringAnimation();

            GameObject paper = Instantiate(paperPrefab, muzzle.position, Quaternion.identity);
            Rigidbody rb = paper.GetComponent<Rigidbody>();
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Vector3 shootDirection = Camera.main.transform.forward;
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                shootDirection = (hit.point - muzzle.position).normalized;
            }
            paper.transform.forward = shootDirection;
            if (rb != null)
            {
                rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
            }
        }
    }
    void PlayFiringAnimation()
    {
        switch (currentMovementState)
        {
            case MovementState.Idle:
                animator.SetTrigger("IdleFire");
                break;
            case MovementState.Walking:
                animator.SetTrigger("WalkFire");
                break;
            case MovementState.Running:
                animator.SetTrigger("RunFire");
                break;
        }
    }
}