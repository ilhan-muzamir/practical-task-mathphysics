using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
/*{
    public Transform player; // Reference to the player's transform
    public float smoothSpeed = 0.125f; // Smoothness of the follow movement
    public Vector3 offset; // Offset from the player's position

    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position of the follower
            Vector3 desiredPosition = player.position + offset;

            // Smoothly interpolate between the current position and the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the position of the follower
            transform.position = smoothedPosition;
        }
    }
}
*/

{
    public Transform player; // Reference to the player's transform
    public float moveSpeed = 5f; // Speed of the enemy movement

    private bool isFollowing = true; // Flag to control whether the enemy is following the player

    void Update()
    {
        if (isFollowing && player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move the enemy towards the player
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the "House" GameObject
        if (other.CompareTag("House"))
        {
            // Stop the enemy from following the player when colliding with the "House" object
            isFollowing = false;
            Debug.Log("Stop");
        }
    }
}
