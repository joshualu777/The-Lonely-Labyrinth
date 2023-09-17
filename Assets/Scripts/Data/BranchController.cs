using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchController : MonoBehaviour
{
    public bool disabled;
    public float max = 1_000_000.0f;

    public bool visited = false;
    float timeVisited;

    TimerController timerController;
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController");
        timerController = gameManager.GetComponent<TimerController>();
        timeVisited = max;
        if (disabled)
        {
            visited = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!visited && collision.gameObject.tag == "Player")
        {
            visited = true;
            timeVisited = timerController.getExactTime();
        }
    }
    public float getTimeVisited()
    {
        return timeVisited;
    }
}