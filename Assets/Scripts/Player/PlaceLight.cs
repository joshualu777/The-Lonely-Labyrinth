using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlaceLight : MonoBehaviour
{
    public GameObject starLight;

    public float closeDistance;
    public int maxLights;

    public static int totalLights = 0;
    public static int activeLights = 0;
    public static int maxActiveLights = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeLights < maxLights)
        {
            AudioController.Instance.playPlace();
            GameObject newLight = Instantiate(starLight);
            newLight.transform.position = transform.position;
            totalLights++;
            activeLights++;
            maxActiveLights = Math.Min(99, Math.Max(maxActiveLights, activeLights));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            bool collected = false;
            GameObject[] lights = GameObject.FindGameObjectsWithTag("Star");
            foreach (GameObject obj in lights)
            {
                if (Vector3.Distance(obj.transform.position, transform.position) <= closeDistance)
                {
                    collected = true;
                    Destroy(obj);
                    activeLights--;
                }
            }
            if (collected)
            {
                AudioController.Instance.playPickUp();
            }
        }
    }
    public static void resetLights()
    {
        totalLights = 0;
        activeLights = 0;
        maxActiveLights = 0;
    }
}
