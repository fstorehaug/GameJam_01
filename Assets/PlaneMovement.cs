using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlaneMovement : MonoBehaviour
{
    public InputAction movePlane;

    private float desierdPitch;
    private float desierRoll;

    private float rotationSpeed = 70f; 
    // Start is called before the first frame update
    void Start()
    {
        movePlane.Enable();
        desierdPitch = transform.rotation.eulerAngles.z;
        desierRoll = transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = movePlane.ReadValue<Vector2>()*Time.deltaTime*rotationSpeed;
        desierdPitch = Mathf.Clamp( desierdPitch + input.x, -60, 60);
        desierRoll = Mathf.Clamp( desierRoll + input.y, -60, 60);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler( new Vector3(desierRoll, 0f, desierdPitch)), Time.deltaTime);

    }
}
