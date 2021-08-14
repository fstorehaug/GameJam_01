using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    private bool victoryAchieved = false;
    public static UnityAction onVictory; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            victoryAchieved = true;
            onVictory?.Invoke();
        }
    }

    public bool getVictoryAchieved()
    {
        return victoryAchieved;
    }


}
