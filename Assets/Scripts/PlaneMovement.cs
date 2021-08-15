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

    private float _desiredPitch;
    private float _desiredRoll;

    private const float RotationSpeed = 70f;

    // Start is called before the first frame update
    void Start()
    {
        KillScript.onDeath += resetPlane;
        Victory.onVictory += resetPlane;
        movePlane.Enable();
        _desiredPitch = transform.rotation.eulerAngles.z;
        _desiredRoll = transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = movePlane.ReadValue<Vector2>() * Time.deltaTime * RotationSpeed;
        _desiredPitch = Mathf.Clamp(_desiredPitch + input.x, -60, 60);
        _desiredRoll = Mathf.Clamp(_desiredRoll + input.y, -60, 60);

        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.Euler(new Vector3(_desiredRoll, 0f, _desiredPitch)), Time.deltaTime);
    }

    private void resetPlane()
    {
        _desiredPitch = 0;
        _desiredRoll = 0;
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
    }
}