using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplayController : MonoBehaviour
{
    GameObject player;
    CompassController compassController;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        compassController = player.GetComponent<CompassController>();
    }

    void Update()
    {
        gameObject.GetComponent<Text>().text = compassController.getTrackDist();
    }
}
