using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMotion : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.useGravity = false;
            rigidbody.velocity = Vector3.zero;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        KillScript.onDeath += ResetPlayer;
        Victory.onVictory += ResetPlayer;

    }

    private void ResetPlayer()
    {
        // Reset Player position
        var playerTransform = transform;
        playerTransform.position = new Vector3(0.5f, 1, 0.5f);
        playerTransform.rotation = Quaternion.identity;

        // Reset Player velocity
        var rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}
