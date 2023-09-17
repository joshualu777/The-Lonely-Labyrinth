using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public float difference = 0.01f;
    public float detectionRadius;

    GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if (player != null)
        {
            float distance = (this.transform.position - player.transform.position).magnitude;
            if (distance <= detectionRadius)
            {

            }
        }
    }
}
