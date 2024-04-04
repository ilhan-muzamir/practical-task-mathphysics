using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 20f, layerMask))
        {
            Debug.Log("Hit something");

            // Check if the hit object is tagged as "Zombie"
            if (hitInfo.collider.CompareTag("Zombie"))
            {
                Debug.Log("Hit a Zombie!");
                Destroy(hitInfo.collider.gameObject); // Destroy the zombie
            }

            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance, Color.red);
        }
        else
        {
            Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.forward * 50f, Color.green);
        }
    }
}
