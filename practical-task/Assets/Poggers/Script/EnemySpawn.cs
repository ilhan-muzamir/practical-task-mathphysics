using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public Transform spawnPoint;   // The position where enemies will spawn
    public int numberOfEnemies = 10; // Number of enemies to spawn
    public float spawnInterval = 2f; // Time interval between each enemy spawn
    public float StartX = -10f; // Minimum X position
    public float EndX = 10f; // Maximum X position

    private void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        // Loop to spawn the specified number of enemies
        for (int i = 0; i < numberOfEnemies; i++)
        {
            // Generate a random X position within the specified range
            float randomX = Random.Range(StartX, EndX);

            // Create a spawn position using the random X position and the spawnPoint's Y and Z positions
            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

            // Instantiate enemy prefab at the generated spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
