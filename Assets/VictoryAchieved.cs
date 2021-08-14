using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryAchieved : MonoBehaviour
{
    [SerializeField]
    private Text victoryAchievedText;
    // Start is called before the first frame update
    void Start()
    {
        victoryAchievedText.CrossFadeAlpha(0f, 0f, false);
        Victory.onVictory += displayVictoryAchieved; 
    }

    public void displayVictoryAchieved()
    {
        victoryAchievedText.CrossFadeAlpha(1.0f, 0.5f, false);
        victoryAchievedText.CrossFadeAlpha(0.0f, 5f, false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
