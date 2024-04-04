using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Distance : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;
    [SerializeField] private TMP_Text distanceText;

    private float distance;

    private void Update()
    {
        // Calculate distance value by Z axis
        distance = Mathf.Abs(checkpoint.position.z - transform.position.z);

        // Display distance value via UI text
        distanceText.text = "House Distance: " + distance.ToString("F1") + " Meters";

        // If the object reaches checkpoint then the distance text shows "FINISH!"
        if (distance <= 0)
        {
            distanceText.text = "FINISH!";
        }
    }
}

