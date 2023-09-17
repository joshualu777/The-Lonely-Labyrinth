using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    private float curTime;
    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            resetTime();
        }
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            curTime += Time.deltaTime;
        }
    }
    public float getExactTime()
    {
        return curTime;
    }
    public int getCurTime()
    {
        return (int) curTime;
    }
    public void resetTime()
    {
        curTime = 0;
    }
    public string getFormatTime()
    {
        int seconds = getCurTime();
        int minutes = (int) (seconds / 60);
        seconds -= minutes * 60;
        return string.Format("{0:00}:{1:00}", Math.Min(99, minutes), seconds);
    }
}