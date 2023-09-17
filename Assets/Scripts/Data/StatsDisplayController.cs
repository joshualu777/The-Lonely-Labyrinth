using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplayController : MonoBehaviour
{
    GameObject statsObject;
    StatisticsController statsController;
    void Start()
    {
        statsObject = GameObject.FindGameObjectWithTag("StatisticsController");
        statsController = statsObject.GetComponent<StatisticsController>();
    }
    void Update()
    {
        statsController.collectData();
        gameObject.GetComponent<Text>().text = statsController.formatData();
    }
}