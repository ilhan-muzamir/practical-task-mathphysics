using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float destroyDelay = 1f;
    public UnityEvent OnZombieHit;
    KillCounter killCounterScript;

    private void Start()
    {
        killCounterScript=GameObject.Find("KCO").GetComponent<KillCounter>();
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
            Destroy(gameObject);
            killCounterScript.AddKill();
        }
    }
        
}
