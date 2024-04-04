using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab to spawn
    public Transform spawnPoint;   // The position where enemies will spawn
    public int numberOfEnemies = 10; // Number of enemies to spawn
    public float spawnInterval = 2f; // Time interval between each enemy spawn

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
            // Instantiate enemy prefab at the spawn point
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            // Wait for the specified spawn interval before spawning the next enemy
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}

