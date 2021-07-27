using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject MainMenuPanel;
    public GameObject OptionsPanel;
    public GameObject CreditsPanel;
    public GameObject PausePanel;
    public GameObject InstructionsPanel;
    public GameObject GamePanel;
    public GameObject ScenePanel;
    public GameObject InteractionPanel;

    [Header("Sub-Panels")]
    //Maybe?

    [Header("Other")]
    public GameController gameController;
    List<GameObject> gameObjects = new List<GameObject>();
    public AudioMixer mixer;
    public AudioController audioController;
    private SceneController sceneController;
    public TMP_Text timer;
    private int playing;
    private bool runOnce;

    private void Start()
    {
    }

    private void OnEnable()
    {
        Time.timeScale = 1;
        GameController.Instance.state = eState.TITLE;
    }

    private void Update()
    {
        if (GameController.Instance.state == eState.GAME && runOnce == true)
        {
            //timer.text = "5:00";
            //runOnce = false;
            gameTrackPlayer();
        }
    }

    private void gameTrackPlayer()
    {
        audioController.Play("Music");
    }

    public void Disable()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            gameObject.SetActive(false);
        }
    }

    public void StartGame()
    {
        GameController.Instance.state = eState.GAME;
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        Debug.Log("Start Game");
        
    }

    //public void GameplayStart()
    //{
    //    Disable();
    //    gameTrackPlayer();
    //    Time.timeScale = 1;
    //    GameController.Instance.state = eState.GAME;
    //    GamePanel.SetActive(true);
    //}

    public void ResumeGame()
    {
        Disable();
        Time.timeScale = 1;
        GamePanel.SetActive(true);
        GameController.Instance.state = eState.GAME;
        Debug.Log("Resume Game");
    }

    public void Options()
    {
        Disable();
        OptionsPanel.SetActive(true);
        Debug.Log("Options menu");
    }

    public void Instructions()
    {
        Disable();
        InstructionsPanel.SetActive(true);
        //GameController.Instance.state = eState.INSTRUCTIONS;
    }

    public void Credits()
    {
        Disable();
        CreditsPanel.SetActive(true);
        Debug.Log("Credits menu");
    }

    public void Back()
    {
        Disable();

        if (GameController.Instance.state == eState.PAUSE)
        {
            BackToPause();
        }
        else
        {
            BackToMenu();
        }
    }

    public void Pause()
    {
        if (GameController.Instance.state == eState.GAME)
        {
            Time.timeScale = 0;
            Disable();
            PausePanel.SetActive(true);
            GameController.Instance.state = eState.PAUSE;
        }
    }

    public void Interaction()
    {
        if(GameController.Instance.state == eState.GAME)
        {
            Disable();
            InteractionPanel.SetActive(true);
        }
    }

    //Back to main menu
    public void BackToMenu()
    {
        Disable();
        MainMenuPanel.SetActive(true);
        GameController.Instance.state = eState.TITLE;
    }

    //Back to pause menu
    public void BackToPause()
    {
        Disable();
        PausePanel.SetActive(true);
        GameController.Instance.state = eState.PAUSE;
    }

    public void SetLevelMST(float sliderValue)
    {
        mixer.SetFloat("MST", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelBGM(float sliderValue)
    {
        mixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }

    public void SetLevelSFX(float sliderValue)
    {
        mixer.SetFloat("SFX", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelAMB(float sliderValue)
    {
        mixer.SetFloat("AMB", Mathf.Log10(sliderValue) * 20);
    }
    public void SetLevelPitch(float sliderValue)
    {
        mixer.SetFloat("Pitch", sliderValue);
    }

    public void Mute(bool mute)
    {
        if (mute) mixer.SetFloat("MST", -80);
        else mixer.SetFloat("MST", 0);
    }

    public void ResetApplication()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}