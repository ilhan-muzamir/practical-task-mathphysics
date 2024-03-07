using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
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

