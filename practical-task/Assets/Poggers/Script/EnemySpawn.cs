using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public Transform spawnPoint;      // The position where enemies will spawn
    public int numberOfEnemies = 10;  // Number of enemies to spawn
    public float spawnInterval = 2f;  // Time interval between each enemy spawn
    public float startX = -10f;       // Minimum X position
    public float endX = 10f;          // Maximum X position

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
            // Get a random enemy prefab from the array
            GameObject randomEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

            // Generate a random X position within the specified range
            float randomX = Random.Range(startX, endX);

            // Create a spawn position using the random X position and the spawnPoint's Y and Z positions
            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

            // Instantiate the random enemy prefab at the generated spawn position
            Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
