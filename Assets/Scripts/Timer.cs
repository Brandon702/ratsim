using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject timer;

    private void OnTriggerEnter(Collider collide)
    {
        if(collide.tag == "Player")
        {
            timer.SetActive(true);
        }
    }

    
}
