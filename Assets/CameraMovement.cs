using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Plane = System.Numerics.Plane;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;

    public GameObject plane;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var t = transform;
        t.LookAt(player.transform);

        var distanceToPlayer = Vector3.Magnitude(t.position - player.transform.position);
        var distanceToPlane = Vector3.Project(transform.position, plane.transform.up).magnitude;

        t.RotateAround(player.transform.position, plane.transform.up, .1f*(7-distanceToPlayer));

        if (distanceToPlayer > 7)
        {
            t.Translate(t.forward *= .1f * distanceToPlayer);
        }

        if (distanceToPlane < 5)
        {
            t.Translate(.1f * plane.transform.up);
        }
    }
}