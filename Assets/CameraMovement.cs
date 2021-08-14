using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plane = System.Numerics.Plane;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject plane;

    private float desierdDistance = 7f;
    private float cameraMovespeed = 0.1f;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, CalculateDesierdPosition(), 0.4f);
        transform.LookAt(player.transform.position);
    }

    private Vector3 CalculateDesierdPosition()
    {
        Transform t = transform;
        Vector3 desierdPosition = t.position;
        var distanceToPlayer = Vector3.Magnitude(t.position - player.transform.position);
        var distanceToPlane = Vector3.Project(t.position, plane.transform.up).magnitude;

        if (distanceToPlayer > desierdDistance)
        {
            desierdPosition += (player.transform.position - desierdPosition).normalized*(Mathf.Abs(distanceToPlayer - desierdDistance)*cameraMovespeed);
        }
        else
        {
            desierdPosition += (desierdPosition- player.transform.position).normalized * (Mathf.Abs(distanceToPlayer - desierdDistance) * cameraMovespeed);
        }

        if (distanceToPlane < 5)
        {
            desierdPosition += plane.transform.up * Mathf.Abs(5 - distanceToPlane) * cameraMovespeed; 
        }

        return desierdPosition;
    }
}