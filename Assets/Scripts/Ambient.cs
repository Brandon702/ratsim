using UnityEngine;
using System.Collections.Generic;


public class Ambient : MonoBehaviour
{
    public int selection;
    private List<bool> interactions = new List<bool>();
    private MenuController menuController;

    private void Start()
    {
        interactions.Add(false);
        interactions.Add(false);
        interactions.Add(false);
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactions[selection] = true;
        if(interactions[0])
        {
            Debug.Log("Amb1");
            menuController.AmbientOnePlayer();
        }
        else if (interactions[1])
        {
            Debug.Log("Amb2");
            menuController.AmbientTwoPlayer();
        }
        else
        {
            Debug.Log("Amb3");
            menuController.AmbientThreePlayer();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactions[selection] = false;
    }
}

