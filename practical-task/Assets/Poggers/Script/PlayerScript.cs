using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;
    [SerializeField] private TMP_Text distanceText;
    public TMP_Text timerText;
    public TMP_Text finaltimerText;
    public float totalTime = 60f;
    public GameObject losePopup;
    private float currentTime;
    private bool hasLost = false;

    private float distance;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float shootInterval = 0.5f;

    public int curHealth = 0;
    public int maxHealth = 100;
    public HealthBar_Script healthBar;
    public GameObject GameComp;

    private void Start()
    {
        // Start the coroutine for auto shooting
        StartCoroutine(AutoShootCoroutine());
        curHealth = maxHealth;
        currentTime = totalTime;

    }


    public void DamagePlayer(int damage)
    {
        curHealth -= damage;
        healthBar.SetHealth(curHealth);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            DamagePlayer(10);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("House"))
        {
            GameComp.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Pop-up");
        }
    }

    private void Update()
    {
        if (!hasLost)
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
                HandleLose();
            }
        }

        // Calculate distance value by Z axis
        distance = Mathf.Abs(checkpoint.position.z - transform.position.z);

        // Display distance value via UI text
        distanceText.text = "Castle Distance: " + distance.ToString("F1") + " Meters";

        // If the object reaches checkpoint then the distance text shows "FINISH!"
        if (distance <= 0)
        {
            distanceText.text = "FINISH!";
        }
    }

    // Method to update timer display
    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        finaltimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to handle losing
    void HandleLose()
    {
        hasLost = true;

        if (losePopup != null)
        {
            losePopup.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Debug.LogError("Lose popup reference is not set!");
        }
    }

    // Coroutine for auto shooting
    private IEnumerator AutoShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    // Method to shoot
    private void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
