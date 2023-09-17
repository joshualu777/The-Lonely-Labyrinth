using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimeController : MonoBehaviour
{

    GameObject timer;
    TimerController timerController;
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("GameController");
        timerController = timer.GetComponent<TimerController>();
    }
    void Update()
    {
        if ((int)(timerController.getCurTime() / 60) < 60)
        {
            gameObject.GetComponent<Text>().text = timerController.getFormatTime();
        }
    }
}
