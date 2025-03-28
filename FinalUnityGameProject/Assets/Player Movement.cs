using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    CharacterController characterController;
    public float speed = 5f;
    private Vector3 direction;
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
      float forwardInput = Input.GetAxis("Vertical");
      float rightInput = Input.GetAxis("Horizontal");
      Vector3 forward = Camera.main.transform.forward;
      Vector3 right = Camera.main.transform.right;


        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        direction = (forwardInput * forward) + (rightInput * right);
        direction.Normalize();
        direction.y = 0f;
        characterController.Move(direction * speed * Time.deltaTime);
        
    }
    
    
}
