using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillScript : MonoBehaviour
{
    public AudioSource killSound;
    public static UnityAction onDeath;

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            return;
        }
        killSound.Play();
        onDeath?.Invoke();

        // Reset Player position
        var playerTransform = other.transform;
        playerTransform.position = new Vector3(0.5f, 5, 0.5f);
        playerTransform.rotation = Quaternion.identity;

        // Reset Player velocity
        var rigidBody = other.GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
    }
}