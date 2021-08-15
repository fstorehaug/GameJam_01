using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryCounter : MonoBehaviour
{
    [SerializeField]
    private Text victoryCounterText;
    private int numVictories;

    public void updateNumVictories() {
        numVictories++;
        victoryCounterText.text = "Victories: " + numVictories.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        victoryCounterText.text = "Victories: 0";
        Victory.onVictory += updateNumVictories;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
