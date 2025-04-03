using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOutput : MonoBehaviour
{
    CameraInput thirdPersonCamera;
    
    
    // Start is called before the first frame update
    void Start()
    {
        thirdPersonCamera = GetComponent<CameraInput>();
        
    }


    // Update is called once per frame
    void Update()
    {
        HandleCameraInput();
        
    }


    void HandleCameraInput()
    {
        thirdPersonCamera.AddXAxisInput(Input.GetAxis("Mouse Y") * Time.deltaTime);
        thirdPersonCamera.AddYAxisInput(Input.GetAxis("Mouse X") * Time.deltaTime);
    }

}
