using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    GameObject gameManager;
    private TimerController timerController;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        timerController = gameManager.GetComponent<TimerController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioController.Instance.playEnd();
            BGMController.Instance.playUI(AudioController.Instance.endSFX);
            GameObject statsObject = GameObject.FindGameObjectWithTag("StatisticsController");
            StatisticsController statsController = statsObject.GetComponent<StatisticsController>();
            statsController.collectData();
            SceneManager.LoadScene("End Screen");
        }
    }
}
