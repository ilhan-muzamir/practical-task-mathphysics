using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float totalTime = 60f; // Total time for the timer

    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Decrease time by deltaTime
            UpdateTimerDisplay();
        }
        else
        {
            // Timer reaches 0, handle the end of the timer
            currentTime = 0f; // Clamp the timer to prevent negative values
            // Add your code to handle the end of the timer here
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
