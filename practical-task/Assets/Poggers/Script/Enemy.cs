using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 2f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) // Check if the player object is null
            return;

        // Calculate direction to the player
        Vector3 direction = player.position - transform.position;
        // Calculate rotation towards the player
        Quaternion rotation = Quaternion.LookRotation(direction);
        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    // Called when this object collides with another collider
    private void OnCollisionEnter(Collision other)
    {
        // Check if the collider has the tag "Bullet"
        if (other.gameObject.CompareTag("Bullet"))
        {
            // Destroy this enemy object
            Destroy(gameObject);
            // Destroy the bullet object as well
            Destroy(other.gameObject);
        }
    }
}
