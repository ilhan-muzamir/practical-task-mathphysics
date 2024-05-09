using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;        


public class KillCounter : MonoBehaviour
{
    public TMP_Text killCountText;
    public TMP_Text FinalkillCountText;
    private int killCount = 0;

    // This method will be called whenever an enemy is killed
    public void IncrementKillCount()
    {
        killCount++;
        // Update the UI text to display the current kill count
        killCountText.text = " " + killCount.ToString();
        FinalkillCountText.text = " " + killCount.ToString();
        Debug.Log("Kill count incremented! Current kill count: " + killCount);
    }
}

