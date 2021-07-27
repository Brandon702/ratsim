using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;

    bool keepTiming;
    float timer;

    public GameController gameController;

    public void Start()
    {
        StartTimer();
    }

    public void Update()
    {
        if (keepTiming)
        {
            UpdateTime();
        }

        //if(timerText.text == "0:10:11")
        if(timer >= 20.0f)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    public void UpdateTime()
    {
        timer = Time.time - startTime;
        timerText.text = TimeToString(timer);
    }

    public void StopTimer()
    {
        string time = timer.ToString();
        keepTiming = false;
    }

    public void StartTimer()
    {
        keepTiming = true;
        startTime = Time.time;
    }

    public string TimeToString(float t)
    {
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        return minutes + ":" + seconds;
    }
}
