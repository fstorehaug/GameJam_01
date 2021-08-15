using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KillScript : MonoBehaviour
{
    public static UnityAction onDeath;

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            return;
        }
        onDeath?.Invoke();
    }
}