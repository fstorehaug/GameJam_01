using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMovement : MonoBehaviour
{
    public InputAction movePlane; 
    // Start is called before the first frame update
    void Start()
    {
        movePlane.Enable();
        movePlane.performed += updateTransform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateTransform(InputAction.CallbackContext cxt)
    {
        Vector2 input = cxt.ReadValue<Vector2>();
        
        transform.Rotate(new Vector3(input.y, 0, -input.x));
        
    }
}
