using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public enum eState
{
    TITLE,
    GAME,
    PAUSE,
    GAMEOVER,
    INSTRUCTIONS,
    MENU,
    EXITGAME
}

public class GameController : MonoBehaviour
{

    #region Singleton
    private static GameController _instance;

    public static GameController Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {

        }
    }
    #endregion



    [Header("Editable values")]
    public eState state = eState.TITLE;

    //Dont touch these variables:
    bool forceOnce = true;
    //InputSystem input;
    private SceneController sceneController;

    public MenuController menuController;

    void Start()
    {
        sceneController = GameObject.Find("SceneController").GetComponent<SceneController>();
    }

    void Update()
    {
        if (state == eState.MENU)
        {
            //turnDisplay.SetActive(false);

            forceOnce = true;
        }

        //Game is running
        if (state == eState.GAME)
        {
            if (forceOnce == true)
            {
                GameSession();

                forceOnce = false;
            }
        }
    }

    public void GameSession()
    {
        //Run once on game start things go here
    }

    /// <summary>
    /// Goes to the next in game scene panel
    /// </summary>
    public void Next()
    {
        //Go to the next section/panel based on position
        //Use scene section int in an if/switch to progress
    }

    private void EndGameScene()
    {
        //Goes to the final panel for the game over
        sceneController.sceneSection++;
    }
}


