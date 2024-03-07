using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMov : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - Player.transform.position;

    }

    // LateUpdate is called once per frame
    void LateUpdate()
    {
        transform.position = offset + Player.transform.position;
    }
}
