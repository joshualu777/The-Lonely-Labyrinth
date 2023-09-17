using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    public Text totalCnt;
    public Text activeCnt;
    void Update()
    {
        totalCnt.text = string.Format("{0:00}", Math.Min(99, PlaceLight.totalLights));

        if (SceneManager.GetActiveScene().name == "Game")
        {
            activeCnt.text = string.Format("{0:00}", Math.Min(99, PlaceLight.activeLights));
        }
        else if (SceneManager.GetActiveScene().name == "End Screen")
        {
            activeCnt.text = string.Format("{0:00}", Math.Min(99, PlaceLight.maxActiveLights));
        }
    }
}
