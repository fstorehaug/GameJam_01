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
    }
}