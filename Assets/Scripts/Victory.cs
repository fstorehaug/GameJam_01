using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Victory : MonoBehaviour
{
    private bool victoryAchieved = false;
    public static UnityAction onVictory;
    float time = 0f;
    float speed = 0.2f;
    float magnitude = 0.5f;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(time * speed) * magnitude, transform.position.z);
    }


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
