using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform checkpoint;
    [SerializeField] private TMP_Text distanceText;

    private float distance;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public float shootInterval = 0.5f; // Interval between shots

    public int curHealth = 0;
    public int maxHealth = 100; 

    public HealthBar_Script healthBar;

    private void Start()
    {
        // Start the coroutine for auto shooting
        StartCoroutine(AutoShootCoroutine());

        curHealth = maxHealth;

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

    // Coroutine for auto shooting
    private IEnumerator AutoShootCoroutine()
    {
        while (true)
        {
            Shoot(); // Call the shoot method
            yield return new WaitForSeconds(shootInterval); // Wait for the specified interval before shooting again
        }
    }

    // Method to shoot
    private void Shoot()
    {
        // Instantiate the bullet prefab at the spawn point position and rotation
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
