using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void ClickStart()
    {
        PlaceLight.resetLights();
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
            TimerController timerController = gameController.GetComponent<TimerController>();
            timerController.resetTime();
        }
        GameObject statsObject = GameObject.FindGameObjectWithTag("StatisticsController");
        StatisticsController statsController = statsObject.GetComponent<StatisticsController>();
        statsController.resetData();
        AudioController.Instance.playUI();
        SceneManager.LoadScene("Level Selection");
    }
    public void ClickLV(string level)
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        SceneController sceneController = gameController.GetComponent<SceneController>();
        sceneController.setScene(level);
        AudioController.Instance.playStart();
        BGMController.Instance.playGame(AudioController.Instance.startSFX);
        AmbienceController.Instance.playClock(AudioController.Instance.startSFX);
        SceneManager.LoadScene("Game");
    }
    public void ClickTutorial()
    {
        AudioController.Instance.playUI();
        SceneManager.LoadScene("Tutorial");
    }
    public void ClickReturn()
    {
        AudioController.Instance.playUI();
        if (SceneManager.GetActiveScene().name == "Game") {
            BGMController.Instance.playUI(AudioController.Instance.UISFX);
        }
        SceneManager.LoadScene("Main Menu");
    }
    public void ClickBack()
    {
        AudioController.Instance.playUI();
        SceneManager.LoadScene("End Screen");
    }
    public void ClickStats()
    {
        AudioController.Instance.playUI();
        SceneManager.LoadScene("Stats Screen");
    }
    public void ClickQuit()
    {
        AudioController.Instance.playUI();
        Application.Quit();
    }
}
