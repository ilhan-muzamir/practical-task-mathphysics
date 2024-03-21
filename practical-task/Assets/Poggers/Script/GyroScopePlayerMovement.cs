using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScopePlayerMovement : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        float moveSpeed = 3f; // Adjust the speed as needed
        float forwardSpeed = 3f; // Adjust the forward speed as needed

        float horizontalInput = Input.gyro.gravity.x;
        float verticalInput = Input.gyro.gravity.y;

        Vector3 gyroscopeMovement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveDirection = Camera.main.transform.TransformDirection(gyroscopeMovement);

        // Move the player using Rigidbody based on gyroscope input
        GetComponent<Rigidbody>().velocity = new Vector3(moveDirection.x * moveSpeed, GetComponent<Rigidbody>().velocity.y, moveDirection.z * moveSpeed);

        // Move the player forward
        Vector3 forwardMovement = new Vector3(0f, 0f, 1f).normalized;
        Vector3 forwardDirection = Camera.main.transform.TransformDirection(forwardMovement);

        GetComponent<Rigidbody>().velocity += forwardDirection * forwardSpeed * Time.deltaTime;
    }
}
