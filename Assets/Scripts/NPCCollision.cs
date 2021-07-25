using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class NPCCollision : MonoBehaviour
{
    public bool interaction;
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interaction = true;
        text.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interaction = false;
        text.SetActive(false);
    }
}

