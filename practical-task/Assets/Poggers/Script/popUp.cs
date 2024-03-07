using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popUp : MonoBehaviour
{

    public GameObject GameComp;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("House"))
        {
            GameComp.SetActive(true);

            //Time.timeScale = 0f;

            Debug.Log("Pop-up");
        }
    }

}
