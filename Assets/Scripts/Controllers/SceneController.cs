using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

class SceneController : MonoBehaviour
{
    public int sceneSection = 0;
    public TMP_Text sceneText;
    private MenuController menuController;
    public Sprite[] images;
    public bool once = false;
    private bool gameOver = false;
    //Map    0
    //Talk   1
    //Travel 2
    //Forest 3

    public void Start()
    {
        //First scene
        sceneText.text = "First scene text goes here";
        menuController = GameObject.Find("MenuController").GetComponent<MenuController>();
    }

    private void Update()
    {
        if (once == true)
        {
            GameObject.Find("ScenePanel").GetComponent<Image>().sprite = images[0];
            once = false;
        }
    }


    /// <summary>
    /// Goes to the next in game scene panel
    /// </summary>
    public void Next()
    {
        //Go to the next section/panel based on position
        //Use scene section int in an if/switch to progress

        /*
         * Notes:
         * Change image: GameObject.Find("ScenePanel").GetComponent<Image>().sprite = images[#];
         * Start game: menuController.GameplayStart();
         * Disable scenes: menuController.ScenePanel.SetActive(false);
         * Reenable scenes: menuController.ScenePanel.SetActive(true);
         * Reset application: gameOver = true;
         */
        
        if(gameOver != true)
        {
            switch (sceneSection)
            {
                case 1:
                    sceneText.text = "Initial scene goes here";
                    break;
                case 2:
                    sceneText.text = "Scene text goes here";
                    break;
                case 3:
                    sceneText.text = "Scene text goes here";
                    break;
                case 4:
                    sceneText.text = "Scene text goes here";
                    break;
                case 5:
                    sceneText.text = "Scene text goes here";
                    break;
                default:
                    sceneText.text = "[Text Failure] \n Scene section: " + sceneSection + "\n Scenes section does not exist.";
                    break;
            }
        }
        else
        {
            menuController.ResetApplication();

        }
    }
}
