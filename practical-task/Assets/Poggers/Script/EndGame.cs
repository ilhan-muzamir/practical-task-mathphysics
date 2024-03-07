using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Define the tag of the game object that triggers the scene restart
    public string restartTag = "RestartObject";

    // Detect collisions
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the restart tag
        if (collision.gameObject.CompareTag(restartTag))
        {
            // Restart the scene
            RestartScene();
        }
    }

    // Method to restart the scene
    void RestartScene()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}