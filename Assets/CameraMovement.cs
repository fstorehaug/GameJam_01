using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plane = System.Numerics.Plane;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject plane;

    private const float DesiredDistance = 7f;
    private const float CameraVelocity = 0.1f;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CalculateDesiredPosition(), 0.4f);
        transform.LookAt(player.transform.position);
    }

    private Vector3 CalculateDesiredPosition()
    {
        Vector3 desiredPosition = transform.position;
        var distanceToPlayer = Vector3.Magnitude(desiredPosition - player.transform.position);
        var distanceToPlane = Vector3.Project(desiredPosition, plane.transform.up).magnitude;

        if (distanceToPlayer > DesiredDistance)
        {
            desiredPosition += (player.transform.position - desiredPosition).normalized*(Mathf.Abs(distanceToPlayer - DesiredDistance)*CameraVelocity);
        }
        else
        {
            desiredPosition += (desiredPosition- player.transform.position).normalized * (Mathf.Abs(distanceToPlayer - DesiredDistance) * CameraVelocity);
        }

        if (distanceToPlane < 5)
        {
            desiredPosition += plane.transform.up * Mathf.Abs(5 - distanceToPlane) * CameraVelocity; 
        }

        return desiredPosition;
    }
}