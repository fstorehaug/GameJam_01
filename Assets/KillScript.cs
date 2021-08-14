using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillScript : MonoBehaviour
{
    public GameObject plane;
    public AudioSource killSound;
    public static UnityAction onDeath;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            return;
        }
        killSound.Play();

        // Reset Player position
        var playerTransform = other.transform;
        playerTransform.position = new Vector3(0.5f, 5, 0.5f);
        playerTransform.rotation = Quaternion.identity;

        // Reset Player velocity
        var rigidBody = other.GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;

        // Reset Plane
        plane.transform.position = Vector3.zero;
        plane.transform.rotation = Quaternion.identity;
        onDeath?.Invoke();
    }
}