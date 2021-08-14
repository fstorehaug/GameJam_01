using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    [SerializeField]
    private Text deathCounterText;
    private int numDeaths;

    public void updateNumDeaths()
    {
        numDeaths++;
        deathCounterText.text = "Deaths: " + numDeaths.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        deathCounterText.text = "Deaths: 0";
        // TODO: Add subscription to "Death" event
    }

    // Update is called once per frame
    void Update()
    {
        KillScript.onDeath += updateNumDeaths;
    }
}
