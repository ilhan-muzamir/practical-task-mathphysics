using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    [SerializeField]
    LayerMask layerMask;

    void Update()
    {
        //Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //if (Physics.Raycast(ray, out hitinfo, 20f, layerMask, QueryTriggerInteraction.Ignore));
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f))
        {
            Debug.Log("hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            Debug.Log("hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50f, Color.green);
        }
    }


    /*void Update()
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
    */
}
