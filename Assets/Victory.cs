using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private bool victoryAchieved = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            victoryAchieved = true;
            Debug.Log("victoryAchieved");
        }
    }

    public bool getVictoryAchieved()
    {
        return victoryAchieved;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
