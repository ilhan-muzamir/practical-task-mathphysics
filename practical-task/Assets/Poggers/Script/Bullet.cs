using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyDelay = 1f;

    private KillCounter killCounter; // Reference to the KillCounter script

    private void Start()
    {
        // Find the KillCounter script in the scene
        killCounter = FindObjectOfType<KillCounter>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))
        {
            Debug.Log("Bullet hit a zombie!");
            Destroy(other.gameObject); // Destroy the enemy
            killCounter.IncrementKillCount(); // Increment the kill count
        }
        else
        {
            Debug.Log("Bullet hit something else.");
        }
        Destroy(gameObject);
    }
}

/*
{
   public float speed = 10f;
   public float destroyDelay = 1f;

   void Update()
   {
       transform.Translate(Vector3.forward * speed * Time.deltaTime);
       Destroy(gameObject, destroyDelay);
   }

   private void OnTriggerEnter(Collider other)
   {
       if (other.CompareTag("Zombie"))
       {
           Destroy(other.gameObject);
       }
       Destroy(gameObject);
   }
}
*/